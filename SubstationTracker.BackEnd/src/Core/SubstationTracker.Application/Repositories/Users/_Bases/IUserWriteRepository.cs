using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Application.Repositories.Users._Bases;

public interface IUserWriteRepository : IWriteRepositoryWithSoftDelete<User>
{
}