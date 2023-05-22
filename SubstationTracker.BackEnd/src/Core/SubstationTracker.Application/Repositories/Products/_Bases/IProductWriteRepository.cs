using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Products;

namespace SubstationTracker.Application.Repositories.Products._Bases;

public interface IProductWriteRepository : IWriteRepositoryWithSoftDelete<Product>
{
}