using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserVerifications;
using SubstationTracker.Application.Services;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserVerifications;

public class EfUserVerificationWriteRepository : EfAuditedWriteRepositoryWithSoftDelete<UserVerification>,
    IUserVerificationWriteRepository
{
    public EfUserVerificationWriteRepository(DbContext dbContext, RequestService requestService) : base(dbContext, requestService)
    {
    }
}