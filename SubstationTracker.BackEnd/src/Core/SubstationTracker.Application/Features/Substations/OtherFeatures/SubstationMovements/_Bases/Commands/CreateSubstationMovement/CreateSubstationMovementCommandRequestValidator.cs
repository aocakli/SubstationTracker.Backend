namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Commands.CreateSubstationMovement;

public class CreateSubstationMovementCommandRequestValidator : AbstractValidator<CreateSubstationMovementCommandRequest>
{
    public CreateSubstationMovementCommandRequestValidator()
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
    }
}