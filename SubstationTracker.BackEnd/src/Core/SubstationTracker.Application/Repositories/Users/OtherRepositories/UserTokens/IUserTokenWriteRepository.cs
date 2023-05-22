using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;

namespace SubstationTracker.Application.Repositories.Users.OtherRepositories.UserTokens;

public interface IUserTokenWriteRepository : IWriteRepository<UserToken>
{
}