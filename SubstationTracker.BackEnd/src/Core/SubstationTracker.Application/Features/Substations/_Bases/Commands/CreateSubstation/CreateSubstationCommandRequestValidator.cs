using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.Validators;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.CreateSubstation;

public class CreateSubstationCommandRequestValidator : AbstractValidator<CreateSubstationCommandRequest>
{
    public CreateSubstationCommandRequestValidator(LanguageService languageService)
    {
        Include(new SubstationBaseValidator<CreateSubstationCommandRequest>());
        
        RuleFor(x => x.SectorIdentities)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count is 1)
            .WithMessage(languageService.Get(Messages.YouCanOnlyChooseOneSector));
    }
}