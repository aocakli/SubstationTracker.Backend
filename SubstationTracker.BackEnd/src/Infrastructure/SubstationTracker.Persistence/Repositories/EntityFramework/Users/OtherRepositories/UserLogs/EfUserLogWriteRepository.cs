using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserLogs;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserLogs;

public class EfUserLogWriteRepository : EfAuditedWriteRepository<UserLog>, IUserLogWriteRepository
{
    public EfUserLogWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext,
        requestService)
    {
    }
}