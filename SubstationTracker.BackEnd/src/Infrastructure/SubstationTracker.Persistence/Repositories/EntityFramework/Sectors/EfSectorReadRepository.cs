using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Sectors;

public class EfSectorReadRepository : EfReadRepository<Sector>, ISectorReadRepository
{
    public EfSectorReadRepository(DbContext dataContext) : base(dataContext)
    {
    }
}