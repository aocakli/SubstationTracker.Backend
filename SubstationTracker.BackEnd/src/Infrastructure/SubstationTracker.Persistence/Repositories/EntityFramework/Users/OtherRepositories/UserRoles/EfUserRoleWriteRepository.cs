using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserRoles;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserRoles;

public class EfUserRoleWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<UserRole>, IUserRoleWriteRepository
{
    public EfUserRoleWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}