using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Sectors;

namespace SubstationTracker.Domain.Concrete.Products.OtherDomains;

public class ProductSector : HistoryEntityBase, ISoftDelete
{
    public Guid ProductId { get; set; }
    public Guid SectorId { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Product? Product { get; set; }
    public virtual Sector? Sector { get; set; }

    public static ProductSector Create(Guid productId, Guid sectorId)
    {
        return new ProductSector()
        {
            ProductId = productId,
            SectorId = sectorId
        };
    }
}