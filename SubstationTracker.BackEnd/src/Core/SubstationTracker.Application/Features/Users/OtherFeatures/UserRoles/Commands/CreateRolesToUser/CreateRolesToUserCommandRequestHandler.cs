using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserRoles;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Commands.CreateRolesToUser;

public class CreateRolesToUserCommandRequestHandler : IRequestHandler<CreateRolesToUserCommandRequest, IResponse>
{
    private readonly IUserRoleReadRepository _readRepository;
    private readonly IUserRoleWriteRepository _writeRepository;
    private readonly LanguageService _languageService;

    public CreateRolesToUserCommandRequestHandler(IUserRoleWriteRepository writeRepository,
        IUserRoleReadRepository readRepository, LanguageService languageService)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CreateRolesToUserCommandRequest request, CancellationToken cancellationToken)
    {
        var userExistingRoles = await _readRepository.GetAllAsync(_userRole => _userRole.UserId.Equals(request.UserId));

        foreach (var userExistingRole in userExistingRoles)
        {
            var role = request.Roles.FirstOrDefault(_role => _role.Equals(userExistingRole.Role));
            if (role is UserRoleTypes.Unknown)
                continue;

            request.Roles.Remove(role);

            if (request.Roles.Any() is false)
                return new ErrorResponse(_languageService.Get(Messages.UserIsAlreadyHaveTheRoles));
        }

        List<UserRole> userRolesToAdd = request.Roles
            .Select(_role => new UserRole(userId: request.UserId, role: _role))
            .ToList();

        await _writeRepository.CreateBulkAsync(userRolesToAdd);

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.RolesAreNotAddedToTheUser));

        return new SuccessResponse(message: _languageService.Get(Messages.RolesAreAddedToTheUser),
            statusCode: HttpStatusCode.Created);
    }
}