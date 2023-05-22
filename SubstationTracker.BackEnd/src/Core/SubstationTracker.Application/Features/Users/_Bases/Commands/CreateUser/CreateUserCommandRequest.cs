using System.Text.Json.Serialization;
using SubstationTracker.Application.BehaviorPipelines.Logs.Attributes;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users._Bases.Abstracts;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Application.Utilities.Responses.Abstracts;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;

[LogType(LogType.CreateUser)]
public class CreateUserCommandRequest : IUserBase, IRequest<IDataResponse<User>>
{
    public CreateUserCommandRequest()
    {
    }

    public CreateUserCommandRequest(string name, string surname, string email, string password, string confirmPassword,
        HashSet<UserRoleTypes> roles, bool isSaveChanges)
    {
        Name = name;
        Surname = surname;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        Roles = roles;
        IsSaveChanges = isSaveChanges;
    }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    [JsonIgnore] public HashSet<UserRoleTypes>? Roles { get; set; }

    [JsonIgnore] public bool IsSaveChanges { get; set; }
}