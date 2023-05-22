using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;

namespace SubstationTracker.Application.Repositories.Products.ProductSectors;

public interface IProductSectorReadRepository : IReadRepository<ProductSector>
{
    Task<ICollection<GetProductSectorsByProductQueryResponse>> GetProductSectorsByProductAsync(Guid productId);

    Task<IPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>> GetProductsBySectorsAsync(
        HashSet<Guid> sectorIdentities, PaginationRequestBase? pagination = null);
}