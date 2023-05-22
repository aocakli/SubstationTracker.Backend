using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUserId;

public class GetRolesByUserIdQueryRequest : IRequest<IDataResponse<HashSet<UserRoleTypes>>>
{
    public GetRolesByUserIdQueryRequest()
    {
    }

    public GetRolesByUserIdQueryRequest(string userId)
    {
        UserId = userId;
    }

    public string UserId { get; set; }
}