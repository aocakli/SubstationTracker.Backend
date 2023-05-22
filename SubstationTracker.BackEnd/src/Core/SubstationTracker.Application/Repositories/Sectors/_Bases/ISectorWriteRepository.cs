using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Sectors;

namespace SubstationTracker.Application.Repositories.Sectors._Bases;

public interface ISectorWriteRepository : IWriteRepositoryWithSoftDelete<Sector>
{
}