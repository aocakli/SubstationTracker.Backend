using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Dtos;

namespace SubstationTracker.Application.Features.Users._Bases.Dtos;

public class UserDto : DtoBase
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string FullName => string.Join(' ', Name, Surname);

    public string Email { get; set; }

    public UserRoleDto Role { get; set; }
}