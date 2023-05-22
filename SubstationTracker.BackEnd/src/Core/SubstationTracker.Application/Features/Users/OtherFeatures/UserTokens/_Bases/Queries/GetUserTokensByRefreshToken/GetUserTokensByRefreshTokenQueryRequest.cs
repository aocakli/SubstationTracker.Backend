namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Queries.GetUserTokensByRefreshToken;

public class GetUserTokensByRefreshTokenQueryRequest : IRequest<IDataResponse<GetUserTokensByRefreshTokenQueryResponse>>
{
    public Guid UserId { get; set; }
    public string RefreshToken { get; set; }
}