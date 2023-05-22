using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;

namespace SubstationTracker.Application.Repositories.Users.OtherRepositories.UserResetPasswords;

public interface IUserResetPasswordWriteRepository : IWriteRepository<UserResetPassword>
{
}