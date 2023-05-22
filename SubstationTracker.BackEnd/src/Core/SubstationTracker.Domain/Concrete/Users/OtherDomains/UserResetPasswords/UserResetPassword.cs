using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Domain.Concrete.Users.OtherDomains.UserResetPasswords;

public class UserResetPassword : EntityBase
{
    public Guid UserId { get; set; }
    public string Code { get; set; }
    public DateTime ExpiryDate { get; set; }
    
    public virtual User? User { get; set; }
}