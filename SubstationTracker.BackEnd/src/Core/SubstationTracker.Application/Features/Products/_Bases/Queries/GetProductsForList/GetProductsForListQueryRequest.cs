using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;

public class
    GetProductsForListQueryRequest : IPaginationRequest,
        IRequest<IPaginateDataResponse<ICollection<GetProductsForListQueryResponse>>>
{
    public PaginationRequestBase Pagination { get; set; } = null!;
}