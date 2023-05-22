namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.Commands.CreateSectorsToSubstation;

public class CreateSectorsToSubstationCommandRequestValidator : AbstractValidator<CreateSectorsToSubstationCommandRequest>
{
    public CreateSectorsToSubstationCommandRequestValidator()
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
        RuleFor(x => x.SectorIdentities).NotNull().NotEmpty();
    }
}