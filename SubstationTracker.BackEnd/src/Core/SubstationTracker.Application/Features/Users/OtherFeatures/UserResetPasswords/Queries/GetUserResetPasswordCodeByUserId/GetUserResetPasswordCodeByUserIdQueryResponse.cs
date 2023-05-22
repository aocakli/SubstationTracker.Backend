namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    GetUserResetPasswordCodeByUserId;

public class GetUserResetPasswordCodeByUserIdQueryResponse
{
    public GetUserResetPasswordCodeByUserIdQueryResponse()
    {
    }

    public GetUserResetPasswordCodeByUserIdQueryResponse(string email, string code, DateTime expiryDate)
    {
        Email = email;
        Code = code;
        ExpiryDate = expiryDate;
    }
    public string Email { get; set; }
    public string Code { get; set; }
    public DateTime ExpiryDate { get; set; }
}