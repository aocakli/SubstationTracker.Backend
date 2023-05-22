using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.LoginUser;

public class LoginUserQueryResponse : UserLoginDto
{
    public UserTokenDto AccessToken { get; set; }
}