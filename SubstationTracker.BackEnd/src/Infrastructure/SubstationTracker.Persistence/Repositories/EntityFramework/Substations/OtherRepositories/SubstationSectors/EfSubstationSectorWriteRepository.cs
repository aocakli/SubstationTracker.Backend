using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationSectors;

public class EfSubstationSectorWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<SubstationSector>,
    ISubstationSectorWriteRepository
{
    public EfSubstationSectorWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}