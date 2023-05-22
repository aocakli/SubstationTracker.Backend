using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Commands.CreateRolesToUser;

public class CreateRolesToUserCommandRequest : IRequest<IResponse>
{
    public CreateRolesToUserCommandRequest()
    {
    }

    public CreateRolesToUserCommandRequest(Guid userId,
        HashSet<Domain.Concrete.Users.OtherDomains.UserRoles.Enums.UserRoleTypes> roles,
        bool isSaveChanges = false)
    {
        UserId = userId;
        Roles = roles;
    }

    public Guid UserId { get; set; }
    public HashSet<Domain.Concrete.Users.OtherDomains.UserRoles.Enums.UserRoleTypes> Roles { get; set; }

    [JsonIgnore] public bool IsSaveChanges { get; set; }
}