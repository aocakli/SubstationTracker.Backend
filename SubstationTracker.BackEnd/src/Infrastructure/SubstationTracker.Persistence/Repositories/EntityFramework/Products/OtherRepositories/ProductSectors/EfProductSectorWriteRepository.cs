using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Products.OtherRepositories.ProductSectors;

public class EfProductSectorWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<ProductSector>, IProductSectorWriteRepository
{
    public EfProductSectorWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}