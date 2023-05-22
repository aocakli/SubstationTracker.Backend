
namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Dtos;

public class UserTokenDto
{
    public UserTokenDto()
    {
    }

    public UserTokenDto(string token, DateTime tokenExpiryDate)
    {
        Token = token;
        ExpiryDate = tokenExpiryDate;
    }

    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }
}