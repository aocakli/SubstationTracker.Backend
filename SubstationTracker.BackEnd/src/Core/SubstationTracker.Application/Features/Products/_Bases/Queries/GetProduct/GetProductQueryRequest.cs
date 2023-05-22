namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;

public class GetProductQueryRequest : IRequest<IDataResponse<GetProductQueryResponse>>
{
    public Guid Id { get; set; }
}