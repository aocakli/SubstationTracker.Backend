namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens.OtherFeatures.RefreshTokens.Commands.
    CreateUserRefreshToken;

public class CreateUserRefreshTokenCommandRequestValidator : AbstractValidator<CreateUserRefreshTokenCommandRequest>
{
    public CreateUserRefreshTokenCommandRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotNull()
            .NotEmpty();
    }
}