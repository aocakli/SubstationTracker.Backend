namespace SubstationTracker.Application.Features.Sectors.Commands.UpdateSector;

public class UpdateSectorCommandRequestValidator : AbstractValidator<UpdateSectorCommandRequest>
{
    public UpdateSectorCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Description).MinimumLength(1).When(x => x.Description is not null);
    }
}