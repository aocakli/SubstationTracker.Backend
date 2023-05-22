namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.GetUserResetPasswordCodeByUserId;

public class GetUserResetPasswordCodeByUserIdQueryRequestValidator : AbstractValidator<GetUserResetPasswordCodeByUserIdQueryRequest>
{
    public GetUserResetPasswordCodeByUserIdQueryRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
    }
}