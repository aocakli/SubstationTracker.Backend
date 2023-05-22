using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;

namespace SubstationTracker.Application.Repositories.Users.OtherRepositories.UserVerifications;

public interface IUserVerificationWriteRepository : IWriteRepositoryWithSoftDelete<UserVerification>
{
}