using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Abstracts;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;

namespace SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;

public class UserVerification : HistoryEntityBase, IUserVerificationBase, ISoftDelete
{
    public Guid UserId { get; set; }
    public UserVerificationType VerificationType { get; set; }
    public string Code { get; set; }
    public bool IsUsed { get; set; }
    public DateTime ExpiryDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public virtual User? User { get; set; }
}