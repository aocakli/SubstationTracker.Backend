using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Commands.CreateUserLog;

public class CreateUserLogCommandRequestHandler : IRequestHandler<CreateUserLogCommandRequest, IResponse>
{
    private readonly IUserLogWriteRepository _writeRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly LanguageService _languageService;

    public CreateUserLogCommandRequestHandler(IUserLogWriteRepository writeRepository,
        IHttpContextAccessor httpContextAccessor, LanguageService languageService)
    {
        _writeRepository = writeRepository;
        _httpContextAccessor = httpContextAccessor;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CreateUserLogCommandRequest request, CancellationToken cancellationToken)
    {
        var userIdAsStr = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(_claim =>
            _claim.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? string.Empty;

        if (Guid.TryParse(userIdAsStr, out Guid userIdAsGuid) is false)
            return new ErrorResponse(message: _languageService.Get(Messages.UserIsNotFound));

        UserLog userLogToCreate = UserLog.Create(userId: userIdAsGuid, type: request.Type, parameters: request.Parameters,
            isSuccess: request.IsSuccess);

        await _writeRepository.CreateAsync(userLogToCreate);

        await _writeRepository.SaveChangesAsync();

        return new SuccessResponse(message: _languageService.Get(Messages.UserLogIsCreated));
    }
}