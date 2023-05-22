using SubstationTracker.Application.Constants;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    CheckResetPasswordCodeAndResetPassword;

public class
    CheckResetPasswordCodeAndResetPasswordQueryRequestValidator : AbstractValidator<
        CheckResetPasswordCodeAndResetPasswordQueryRequest>
{
    public CheckResetPasswordCodeAndResetPasswordQueryRequestValidator()
    {
        RuleFor(x => x.ResetPasswordCode)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .MinimumLength(FieldConsts.PasswordMinLength);

        RuleFor(x => x.PasswordConfirm)
            .NotNull()
            .NotEmpty()
            .MinimumLength(FieldConsts.PasswordMinLength);

        RuleFor(x => x.PasswordConfirm)
            .Equal(x => x.Password);
    }
}