using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Products.OtherRepositories.ProductSectors;

public class EfProductSectorReadRepository : EfReadRepository<ProductSector>, IProductSectorReadRepository
{
    public EfProductSectorReadRepository(DbContext dataContext) : base(dataContext)
    {
    }

    public async Task<ICollection<GetProductSectorsByProductQueryResponse>> GetProductSectorsByProductAsync(
        Guid productId)
    {
        return await Query(features: new RepoFeatures(includeAudit: true))
            .Include(_productSector => _productSector.Sector)
            .Where(_productSector => _productSector.ProductId.Equals(productId))
            .Select(_productSector => new GetProductSectorsByProductQueryResponse()
            {
                Id = _productSector.Id,
                SectorId = _productSector.SectorId,
                SectorName = _productSector.Sector!.Name,
                CreatedDate = _productSector.Audit!.CreateAudit!.CreatedDate
            })
            .OrderByDescending(_productSector => _productSector.CreatedDate)
            .ToListAsync();
    }

    public async Task<IPaginateDataResponse<ICollection<GetProductsBySubstationQueryResponse>>>
        GetProductsBySectorsAsync(HashSet<Guid> sectorIdentities, PaginationRequestBase? pagination = null)
    {
        var query = Query(features: new RepoFeatures(includeAudit: true))
            .Include(_productSector => _productSector.Sector)
            .Include(_productSector => _productSector.Product)
            .ThenInclude(_product => _product.Audit)
            .ThenInclude(_audit => _audit.CreateAudit)
            .Where(_productSector => sectorIdentities.Contains(_productSector.SectorId))
            .Select(_productSector => new GetProductsBySubstationQueryResponse()
            {
                Id = _productSector.ProductId,
                Name = _productSector.Product!.Name,
                Unit = _productSector.Product.Unit,
                PhotoPath = _productSector.Product.PhotoPath,
                CreatedDate = _productSector.Product.Audit!.CreateAudit!.CreatedDate
            });

        return await base.PaginateAsync(query: query, pagination: pagination);
    }
}