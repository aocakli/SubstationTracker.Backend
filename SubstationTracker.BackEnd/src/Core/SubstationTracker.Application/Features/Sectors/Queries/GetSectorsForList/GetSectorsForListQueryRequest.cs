using SubstationTracker.Application.BehaviorPipelines.Logs.Attributes;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;

[LogType(LogType.SectorList)]
public class GetSectorsForListQueryRequest : IPaginationRequest, IRequest<IPaginateDataResponse<ICollection<GetSectorsForListQueryResponse>>>
{
    public PaginationRequestBase Pagination { get; set; }
}