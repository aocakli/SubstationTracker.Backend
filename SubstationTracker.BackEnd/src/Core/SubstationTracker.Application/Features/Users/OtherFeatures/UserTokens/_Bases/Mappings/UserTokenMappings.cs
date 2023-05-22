using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserTokens;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Mappings;

public class UserTokenMappings : Profile
{
    public UserTokenMappings()
    {
        CreateMap<UserToken, UserTokenDto>();
    }
}