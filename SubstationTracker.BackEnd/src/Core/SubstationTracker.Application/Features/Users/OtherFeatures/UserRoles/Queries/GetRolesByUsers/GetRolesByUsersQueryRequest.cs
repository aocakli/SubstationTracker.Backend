using SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Dtos;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUsers;

public class GetRolesByUsersQueryRequest : IRequest<IDataResponse<ICollection<UserRoleDto>>>
{
    public GetRolesByUsersQueryRequest()
    {
    }

    public GetRolesByUsersQueryRequest(HashSet<Guid> userIdentities)
    {
        UserIdentities = userIdentities;
    }

    public GetRolesByUsersQueryRequest(Guid userId) : this(new HashSet<Guid>() { userId })
    {
    }

    public HashSet<Guid> UserIdentities { get; set; }
}