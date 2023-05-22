namespace SubstationTracker.Application.Features.Sectors.Commands.SoftDeleteSector;

public class SoftDeleteSectorCommandRequestValidator : AbstractValidator<SoftDeleteSectorCommandRequest>
{
    public SoftDeleteSectorCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}