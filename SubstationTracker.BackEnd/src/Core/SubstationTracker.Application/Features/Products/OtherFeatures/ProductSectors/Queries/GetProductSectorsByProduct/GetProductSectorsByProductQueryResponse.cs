namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;

public class GetProductSectorsByProductQueryResponse
{
    public Guid Id { get; set; }
    public Guid SectorId { get; set; }
    public string SectorName { get; set; }
    public DateTime CreatedDate { get; set; }
}