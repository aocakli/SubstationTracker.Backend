namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.
    GetProductSectorsByProduct;

public class
    GetProductSectorsByProductQueryRequest : IRequest<
        IDataResponse<ICollection<GetProductSectorsByProductQueryResponse>>>
{
    public GetProductSectorsByProductQueryRequest(Guid productId)
    {
        ProductId = productId;
    }
    public Guid ProductId { get; set; }
}