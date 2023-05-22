using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;

public class GetUserListQueryRequest : IPaginationRequest,
    IRequest<IPaginateDataResponse<ICollection<GetUserListQueryResponse>>>
{
    public string? Contains { get; set; }
    public UserRoleTypes? Role { get; set; }
    public PaginationRequestBase Pagination { get; set; } = null!;
}