using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;

public class UserRole : HistoryEntityBase, ISoftDelete
{
    public UserRole()
    {
    }
    public UserRole(Guid userId, UserRoleTypes role)
    {
        UserId = userId;
        Role = role;
    }
    
    public Guid UserId { get; set; }
    public Enums.UserRoleTypes Role { get; set; }

    public bool IsDeleted { get; set; }
    
    public virtual User? User { get; set; }
}