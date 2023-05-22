namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Commands.CreateUserResetPassword;

public class CreateUserResetPasswordCommandRequestValidator : AbstractValidator<CreateUserResetPasswordCommandRequest>
{
    public CreateUserResetPasswordCommandRequestValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty();
    }
}