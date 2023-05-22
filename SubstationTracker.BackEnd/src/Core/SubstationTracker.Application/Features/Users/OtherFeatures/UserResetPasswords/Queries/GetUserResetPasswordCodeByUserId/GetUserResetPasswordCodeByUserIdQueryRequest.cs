using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.GetUserResetPasswordCodeByUserId;

public class GetUserResetPasswordCodeByUserIdQueryRequest : IRequest<IDataResponse<GetUserResetPasswordCodeByUserIdQueryResponse>>
{
    public GetUserResetPasswordCodeByUserIdQueryRequest()
    {
    }

    public GetUserResetPasswordCodeByUserIdQueryRequest(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; set; }
}