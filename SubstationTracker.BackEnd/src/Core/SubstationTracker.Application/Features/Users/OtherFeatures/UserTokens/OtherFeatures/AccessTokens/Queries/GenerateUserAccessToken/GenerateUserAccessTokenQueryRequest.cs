using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.AccessTokens.Queries.
    GenerateUserAccessToken;

public class GenerateUserAccessTokenQueryRequest : IRequest<IDataResponse<GenerateUserAccessTokenQueryResponse>>
{
    public GenerateUserAccessTokenQueryRequest()
    {
    }

    public GenerateUserAccessTokenQueryRequest(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}