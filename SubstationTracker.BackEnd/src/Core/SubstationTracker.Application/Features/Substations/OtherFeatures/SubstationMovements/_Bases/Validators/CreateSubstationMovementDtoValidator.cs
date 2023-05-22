using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Dtos;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Validators;

public class CreateSubstationMovementDtoValidator : AbstractValidator<CreateSubstationMovementDto>
{
    public CreateSubstationMovementDtoValidator()
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
        RuleFor(x => x.ProcessTime).NotNull().NotEmpty();
    }
}