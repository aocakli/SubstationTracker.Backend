namespace SubstationTracker.Application.Features.Substations._Bases.Commands.SoftDeleteSubstation;

public class SoftDeleteSubstationCommandRequestValidator : AbstractValidator<SoftDeleteSubstationCommandRequest>
{
    public SoftDeleteSubstationCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}