namespace SubstationTracker.Application.Features.Sectors.Commands.CreateSector;

public class CreateSectorCommandRequestValidator : AbstractValidator<CreateSectorCommandRequest>
{
    public CreateSectorCommandRequestValidator()
    {
        RuleFor(_request => _request.Name)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Description)
            .MinimumLength(1)
            .When(x => x.Description is not null);
    }
}