using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Dtos;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserRoles;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUsers;

public class
    GetRolesByUsersQueryRequestHandler : IRequestHandler<GetRolesByUsersQueryRequest,
        IDataResponse<ICollection<UserRoleDto>>>
{
    private readonly IUserRoleReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetRolesByUsersQueryRequestHandler(IUserRoleReadRepository readRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<ICollection<UserRoleDto>>> Handle(GetRolesByUsersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userRoles =
            await _readRepository.GetAllAsync(
                exp: _userRole => request.UserIdentities.Contains(_userRole.UserId),
                features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (userRoles.Any() is false)
            return new ErrorDataResponse<ICollection<UserRoleDto>>(
                message: _languageService.Get(Messages.UserRolesAreNotFound));

        List<UserRoleDto> response = new();

        foreach (var userRoleGroup in userRoles.GroupBy(_userRole => _userRole.UserId))
        {
            UserRoleDto userRoleDto = new(
                userId: userRoleGroup.Key,
                rolesCollection: userRoleGroup.Select(_userRole => _userRole.Role).ToHashSet()
            );

            response.Add(userRoleDto);
        }

        return new SuccessDataResponse<ICollection<UserRoleDto>>(
            message: _languageService.Get(Messages.UserRolesAreListed),
            data: response);
    }
}