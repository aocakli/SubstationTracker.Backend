using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens.Abstracts;

namespace SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;

public class UserToken : EntityBase, IUserTokenBase
{
    public UserToken()
    {
    }

    public UserToken(Guid userId, string token, DateTime expiryDate)
    {
        UserId = userId;
        Token = token;
        ExpiryDate = expiryDate;
    }
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }

    public virtual User? User { get; set; }
}