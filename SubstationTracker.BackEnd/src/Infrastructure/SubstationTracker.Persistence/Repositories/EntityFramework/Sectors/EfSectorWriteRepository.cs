using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Sectors;

public class EfSectorWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<Sector>, ISectorWriteRepository
{
    public EfSectorWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}