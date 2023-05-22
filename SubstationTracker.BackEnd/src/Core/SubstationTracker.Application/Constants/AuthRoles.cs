using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Constants;

public class AuthRoles
{
    public const string Unknown = nameof(UserRoleTypes.Unknown);
    public const string SubstationResponsible = nameof(UserRoleTypes.SubstationResponsible);
    public const string Admin = nameof(UserRoleTypes.Admin);
    public const string SubstationResponsibleOrAdmin = $"{SubstationResponsible}, {Admin}";
}