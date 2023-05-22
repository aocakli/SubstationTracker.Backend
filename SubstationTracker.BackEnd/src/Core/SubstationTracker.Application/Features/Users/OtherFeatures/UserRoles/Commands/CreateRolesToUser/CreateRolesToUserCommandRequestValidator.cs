namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Commands.CreateRolesToUser;

public class CreateRolesToUserCommandRequestValidator : AbstractValidator<CreateRolesToUserCommandRequest>
{
    public CreateRolesToUserCommandRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
        RuleFor(x => x.Roles).NotNull().NotEmpty();
    }
}