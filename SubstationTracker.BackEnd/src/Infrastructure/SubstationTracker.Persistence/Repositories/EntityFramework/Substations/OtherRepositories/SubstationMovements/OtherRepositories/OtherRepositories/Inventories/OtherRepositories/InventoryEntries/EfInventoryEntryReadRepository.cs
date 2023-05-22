using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryEntries;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories.OtherRepositories.InventoryEntries;

public class EfInventoryEntryReadRepository : EfReadRepository<InventoryEntry>, IInventoryEntryReadRepository
{
    public EfInventoryEntryReadRepository(DbContext dbContext) : base(dbContext)
    {
    }
}