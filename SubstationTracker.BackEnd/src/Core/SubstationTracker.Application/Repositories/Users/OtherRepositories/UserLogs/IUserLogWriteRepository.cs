using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;

namespace SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;

public interface IUserLogWriteRepository : IWriteRepository<UserLog>
{
}