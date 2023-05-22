using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Application.Repositories.Substations._Bases;

public interface ISubstationWriteRepository : IWriteRepositoryWithSoftDelete<Substation>
{
}