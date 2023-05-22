using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations._Bases;

public class EfSubstationWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<Substation>,ISubstationWriteRepository
{
    public EfSubstationWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}