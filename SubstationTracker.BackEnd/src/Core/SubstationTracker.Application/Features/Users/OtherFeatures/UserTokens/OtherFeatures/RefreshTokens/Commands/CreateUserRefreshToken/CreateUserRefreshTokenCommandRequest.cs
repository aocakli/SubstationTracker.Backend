using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;

public class CreateUserRefreshTokenCommandRequest : IRequest<IDataResponse<CreateUserRefreshTokenCommandResponse>>
{
    public CreateUserRefreshTokenCommandRequest()
    {
    }

    public CreateUserRefreshTokenCommandRequest(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}