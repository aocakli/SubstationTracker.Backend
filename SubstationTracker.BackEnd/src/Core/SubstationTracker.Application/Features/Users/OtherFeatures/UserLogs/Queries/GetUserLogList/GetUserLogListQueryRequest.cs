using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;

public class GetUserLogListQueryRequest : IPaginationRequest,
    IRequest<IPaginateDataResponse<ICollection<GetUserLogListQueryResponse>>>
{
    public Guid? UserId { get; set; }
    public LogType? Type { get; set; }
    public PaginationRequestBase Pagination { get; set; }
}