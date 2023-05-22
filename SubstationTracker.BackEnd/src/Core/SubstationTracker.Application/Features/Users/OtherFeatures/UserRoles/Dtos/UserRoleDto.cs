using System.Text.Json.Serialization;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Dtos;

public class UserRoleDto
{
    public UserRoleDto()
    {
    }

    public UserRoleDto(Guid userId, HashSet<UserRoleTypes> rolesCollection)
    {
        UserId = userId;
        UserRolesCollection = rolesCollection;
    }

    public Guid UserId { get; set; }
    [JsonIgnore] public HashSet<UserRoleTypes> UserRolesCollection { get; }

    public HashSet<string> Roles => UserRolesCollection.Select(_userRole => _userRole.ToString()).ToHashSet();

    public bool IsSubstationResponsible => UserRolesCollection.Any(_role => _role == UserRoleTypes.SubstationResponsible);
    public bool IsAdmin => UserRolesCollection.Any(_role => _role == UserRoleTypes.Admin);
}