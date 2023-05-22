using SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Products;

namespace SubstationTracker.Application.Repositories.Products._Bases;

public interface IProductReadRepository : IReadRepository<Product>
{
    Task<IPaginateDataResponse<ICollection<GetProductsForListQueryResponse>>> GetProductsForListAsync(
        PaginationRequestBase pagination);

    Task<GetProductQueryResponse?> GetProductAsync(Guid id);
}