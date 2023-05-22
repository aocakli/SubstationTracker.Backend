using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    CheckResetPasswordCodeAndResetPassword;

public class CheckResetPasswordCodeAndResetPasswordQueryRequest : IRequest<IResponse>
{
    public string ResetPasswordCode { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}