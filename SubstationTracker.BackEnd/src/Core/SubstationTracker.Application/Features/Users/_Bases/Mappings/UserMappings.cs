using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;
using SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users._Bases.Queries.LoginUser;
using SubstationTracker.Application.Features.Users.OtherFeatures.Admins.Commands.CreateAdmin;

namespace SubstationTracker.Application.Features.Users._Bases.Mappings;

public class UserMappings : Profile
{
    public UserMappings()
    {
        CreateMap<CreateUserCommandRequest, User>();

        CreateMap<User, UserDto>();

        CreateMap<UserDto, LoginUserQueryResponse>();

        CreateMap<CreateAdminCommandRequest, CreateUserCommandRequest>()
            .ForMember(x => x.Roles, mopt => mopt.MapFrom(v => new List<UserRoleTypes> { UserRoleTypes.Admin }));
    }
}