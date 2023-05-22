using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Products._Bases;

public class EfProductWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<Product>, IProductWriteRepository
{
    public EfProductWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}