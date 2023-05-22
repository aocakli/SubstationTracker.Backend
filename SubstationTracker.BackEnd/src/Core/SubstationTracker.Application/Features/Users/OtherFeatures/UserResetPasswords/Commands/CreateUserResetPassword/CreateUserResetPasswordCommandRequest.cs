namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Commands.CreateUserResetPassword;

public class CreateUserResetPasswordCommandRequest : IRequest<IResponse>
{
    public CreateUserResetPasswordCommandRequest()
    {
    }

    public CreateUserResetPasswordCommandRequest(string email)
    {
        Email = email;
    }
    public string Email { get; set; }
}