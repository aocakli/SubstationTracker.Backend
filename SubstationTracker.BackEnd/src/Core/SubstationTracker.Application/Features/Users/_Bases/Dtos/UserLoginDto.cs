using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users._Bases.Dtos;

public class UserLoginDto : UserDto
{
    public UserTokenDto? RefreshToken { get; set; }
}