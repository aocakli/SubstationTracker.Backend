using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationMovements.OtherRepositories._Bases;

public class EfSubstationMovementWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<SubstationMovement>,
    ISubstationMovementWriteRepository
{
    public EfSubstationMovementWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}