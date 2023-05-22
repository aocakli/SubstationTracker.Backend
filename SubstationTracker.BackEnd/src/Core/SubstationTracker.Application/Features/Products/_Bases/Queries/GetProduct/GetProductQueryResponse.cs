using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;

public class GetProductQueryResponse
{
    public Guid Id { get; set; }

    public ICollection<GetProductSectorsByProductQueryResponse> Sectors { get; set; } =
        new List<GetProductSectorsByProductQueryResponse>();

    public string Name { get; set; }
    public string Unit { get; set; }
    public string PhotoPath { get; set; }
    public DateTime CreatedDate { get; set; }
}