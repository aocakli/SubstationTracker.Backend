namespace SubstationTracker.Application.Features.UserAndSubstations.Commands.CreateUserAndAssignToSubstation;

public class
    CreateUserAndAssignToSubstationCommandRequestValidator : AbstractValidator<
        CreateUserAndAssignToSubstationCommandRequest>
{
    public CreateUserAndAssignToSubstationCommandRequestValidator()
    {
        RuleFor(x => x.SubstationId)
            .NotNull()
            .NotEmpty();
    }
}