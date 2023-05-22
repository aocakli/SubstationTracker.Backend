using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users._Bases;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users._Bases;

public class EfUserWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<User>, IUserWriteRepository
{
    public EfUserWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}