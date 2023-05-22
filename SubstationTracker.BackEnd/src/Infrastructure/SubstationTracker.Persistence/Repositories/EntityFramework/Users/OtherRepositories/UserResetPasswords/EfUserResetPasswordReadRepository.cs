using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserResetPasswords;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserResetPasswords;

public class EfUserResetPasswordReadRepository : EfReadRepository<UserResetPassword>, IUserResetPasswordReadRepository
{
    public EfUserResetPasswordReadRepository(DbContext dataContext) : base(dataContext)
    {
    }
}