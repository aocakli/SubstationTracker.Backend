using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories.OtherRepositories.Inventories._Bases;

public class EfInventoryReadRepository : EfReadRepository<Inventory>, IInventoryReadRepository
{
    public EfInventoryReadRepository(DbContext dbContext) : base(dbContext)
    {
    }
}