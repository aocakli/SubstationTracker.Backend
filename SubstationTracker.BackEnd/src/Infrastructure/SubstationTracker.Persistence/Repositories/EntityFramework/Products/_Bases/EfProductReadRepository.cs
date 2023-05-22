using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Products._Bases;

public class EfProductReadRepository : EfReadRepository<Product>, IProductReadRepository
{
    public EfProductReadRepository(DbContext dataContext) : base(dataContext)
    {
    }

    public async Task<IPaginateDataResponse<ICollection<GetProductsForListQueryResponse>>> GetProductsForListAsync(
        PaginationRequestBase pagination)
    {
        var query = Query(features: new RepoFeatures(includeAudit: true))
            .Include(_product => _product.ProductSectors)
            .ThenInclude(_productSector => _productSector.Sector)
            .Select(_product => new GetProductsForListQueryResponse()
            {
                Id = _product.Id,
                SectorNames = _product.ProductSectors.Select(_productSector => _productSector.Sector!.Name).ToHashSet(),
                Name = _product.Name,
                Unit = _product.Unit,
                PhotoPath = _product.PhotoPath,
                CreatedDate = _product.Audit!.CreateAudit!.CreatedDate
            });

        return await base.PaginateAsync(query: query,
            pagination: pagination,
            sortablePropertyExpression: _product => _product.CreatedDate);
    }

    public async Task<GetProductQueryResponse?> GetProductAsync(Guid id)
    {
        return await Query(features: new RepoFeatures())
            .Select(_product => new GetProductQueryResponse()
            {
                Id = _product.Id,
                Name = _product.Name,
                Unit = _product.Unit,
                PhotoPath = _product.PhotoPath,
                CreatedDate = _product.Audit!.CreateAudit!.CreatedDate
            }).FirstOrDefaultAsync(_product => _product.Id.Equals(id));
    }
}