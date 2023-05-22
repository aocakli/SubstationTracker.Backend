using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;

namespace SubstationTracker.Application.Repositories.Products.ProductSectors;

public interface IProductSectorWriteRepository : IWriteRepositoryWithSoftDelete<ProductSector>
{
}