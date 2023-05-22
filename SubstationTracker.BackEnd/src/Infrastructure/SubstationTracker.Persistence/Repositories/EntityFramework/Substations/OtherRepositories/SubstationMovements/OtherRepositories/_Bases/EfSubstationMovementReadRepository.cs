using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.
    OtherRepositories._Bases;

public class EfSubstationMovementReadRepository : EfReadRepository<SubstationMovement>,
    ISubstationMovementReadRepository
{
    public EfSubstationMovementReadRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<ICollection<SubstationMovement>> GetWithIncludesAsync(
        Expression<Func<SubstationMovement, bool>>? exp = null)
    {
        return await Query(features: new RepoFeatures())
            .Include(_substationMovement => _substationMovement.Audit)
            .ThenInclude(_audit => _audit.CreateAudit)
            .ThenInclude(_createAudit => _createAudit.CreatedUser)
            .Include(_substationMovement => _substationMovement.Inventory)
            .ThenInclude(_substationMovement => _substationMovement.InventoryEntry)
            .Include(_substationMovement => _substationMovement.Inventory)
            .ThenInclude(_substationMovement => _substationMovement.InventoryOut)
            .OrderBy(_substationMovement => _substationMovement.ProcessTime)
            .ToListAsync();
    }
}