using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryOuts;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories.OtherRepositories.InventoryOuts;

public class EfInventoryOutReadRepository : EfReadRepository<InventoryOut>, IInventoryOutReadRepository
{
    public EfInventoryOutReadRepository(DbContext dbContext) : base(dbContext)
    {
    }
}