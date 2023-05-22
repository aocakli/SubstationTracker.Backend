using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;

public class
    GetProductsBySubstationQueryRequest : IPaginationRequest, IRequest<
        IPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>>
{
    public GetProductsBySubstationQueryRequest()
    {
        
    }

    public GetProductsBySubstationQueryRequest(Guid userId, Guid substationId, PaginationRequestBase pagination)
    {
        UserId = userId;
        SubstationId = substationId;
        Pagination = pagination;
    }
    public Guid UserId { get; set; }
    public Guid SubstationId { get; set; }
    public PaginationRequestBase Pagination { get; set; } = null!;
}