using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryEntries;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories.OtherRepositories.InventoryEntries;

public class EfInventoryEntryWriteRepository : EfAuditedWriteRepository<InventoryEntry>, IInventoryEntryWriteRepository
{
    public EfInventoryEntryWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext,
        requestService)
    {
    }
}