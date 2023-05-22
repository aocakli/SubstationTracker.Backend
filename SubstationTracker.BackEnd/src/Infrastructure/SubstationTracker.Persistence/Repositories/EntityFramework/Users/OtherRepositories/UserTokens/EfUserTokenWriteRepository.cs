using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserTokens;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserTokens;

public class EfUserTokenWriteRepository : EfWriteRepository<UserToken>, IUserTokenWriteRepository
{
    public EfUserTokenWriteRepository(DbContext dataContext) : base(dataContext)
    {
    }
}