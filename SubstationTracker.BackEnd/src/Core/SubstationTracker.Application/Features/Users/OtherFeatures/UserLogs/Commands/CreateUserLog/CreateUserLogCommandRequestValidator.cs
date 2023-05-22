namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Commands.CreateUserLog;

public class CreateUserLogCommandRequestValidator : AbstractValidator<CreateUserLogCommandRequest>
{
    public CreateUserLogCommandRequestValidator()
    {
        RuleFor(x => x.Type).NotNull().NotEmpty();
        RuleFor(x => x.IsSuccess).NotNull();
    }
}