using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories._Bases;

public class EfInventoryWriteRepository : EfAuditedWriteRepository<Inventory>, IInventoryWriteRepository
{
    public EfInventoryWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}