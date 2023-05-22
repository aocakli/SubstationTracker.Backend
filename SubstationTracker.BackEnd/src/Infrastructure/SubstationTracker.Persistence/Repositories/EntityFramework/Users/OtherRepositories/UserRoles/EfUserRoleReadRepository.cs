using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserRoles;

public class EfUserRoleReadRepository : EfReadRepository<UserRole>, IUserRoleReadRepository
{
    public EfUserRoleReadRepository(DbContext dataContext) : base(dataContext)
    {
    }
}