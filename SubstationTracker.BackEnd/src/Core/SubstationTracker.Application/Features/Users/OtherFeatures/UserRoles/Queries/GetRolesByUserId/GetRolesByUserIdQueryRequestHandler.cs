using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUserId;

public class
    GetRolesByUserIdQueryRequestHandler : IRequestHandler<GetRolesByUserIdQueryRequest,
        IDataResponse<HashSet<UserRoleTypes>>>
{
    private readonly LanguageService _languageService;
    private readonly IUserReadRepository _readRepository;

    public GetRolesByUserIdQueryRequestHandler(IUserReadRepository readRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<HashSet<UserRoleTypes>>> Handle(GetRolesByUserIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        // var userRoles = await _readRepository.GetUserRolesByUserIdAsync(request.UserId);
        // if (userRoles.Any() is false)
        //     return new ErrorDataResponse<HashSet<UserRoles>>(_languageService.Get(Messages.UserRolesAreNotFound));
        //
        // return new SuccessDataResponse<HashSet<UserRoles>>(_languageService.Get(Messages.UserRolesAreListed),
        //     userRoles);

        return null;
    }
}