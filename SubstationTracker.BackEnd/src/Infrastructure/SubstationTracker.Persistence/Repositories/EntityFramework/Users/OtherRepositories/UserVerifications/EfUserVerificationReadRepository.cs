using Microsoft.EntityFrameworkCore;
using SubstationTracker.Application.Repositories.Users.OtherRepositories.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Persistence.Repositories.EntityFramework._Bases;

namespace SubstationTracker.Persistence.Repositories.EntityFramework.Users.OtherRepositories.UserVerifications;

public class EfUserVerificationReadRepository : EfReadRepository<UserVerification>, IUserVerificationReadRepository
{
    public EfUserVerificationReadRepository(DbContext dataContext) : base(dataContext)
    {
    }
}