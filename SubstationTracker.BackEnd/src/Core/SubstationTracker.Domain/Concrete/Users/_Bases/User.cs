using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Abstractions.Audits;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Domain.Concrete.Users._Bases.Abstracts;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;

namespace SubstationTracker.Domain.Concrete.Users._Bases;

public class User : HistoryEntityBase, IUserBase, ISoftDelete
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsDeleted { get; set; }

    public string FullName => string.Join(" ", Name, Surname);

    public virtual List<SubstationResponsibleUser> SubstationResponsibleUsers { get; set; } = new();
    public virtual UserResetPassword? ResetPassword { get; set; }
    public virtual UserToken? RefreshToken { get; set; }
    public virtual List<UserVerification> UserVerifications { get; set; } = new();
    public virtual List<UserRole> UserRoles { get; set; } = new();
    public virtual List<CreateAudit> CreateAudits { get; set; } = new();
    public virtual List<UpdateAudit> UpdateAudits { get; set; } = new();
    public virtual List<DeleteAudit> DeleteAudits { get; set; } = new();
    public virtual List<UserLog> UserLogs { get; set; } = new();
}