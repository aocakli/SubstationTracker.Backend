using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;

public class
    GetSubstationsForListQueryRequest : IPaginationRequest,
        IRequest<IPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>>
{
    public PaginationRequestBase Pagination { get; set; }
}