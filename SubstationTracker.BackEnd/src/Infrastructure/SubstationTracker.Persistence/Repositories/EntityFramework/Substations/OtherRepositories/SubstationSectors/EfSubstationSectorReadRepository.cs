using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Substations.OtherRepositories.SubstationSectors;

public class EfSubstationSectorReadRepository : EfReadRepository<SubstationSector>, ISubstationSectorReadRepository
{
    public EfSubstationSectorReadRepository(DbContext dataContext) : base(dataContext)
    {
    }
}