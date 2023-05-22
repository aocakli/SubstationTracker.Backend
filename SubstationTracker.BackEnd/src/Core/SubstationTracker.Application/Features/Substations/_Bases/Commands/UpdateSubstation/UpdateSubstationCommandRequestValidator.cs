using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.Validators;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.UpdateSubstation;

public class UpdateSubstationCommandRequestValidator : AbstractValidator<UpdateSubstationCommandRequest>
{
    public UpdateSubstationCommandRequestValidator(LanguageService languageService)
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        Include(new SubstationBaseValidator<UpdateSubstationCommandRequest>());
        
        RuleFor(x => x.SectorIdentities)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count is 1)
            .WithMessage(languageService.Get(Messages.YouCanOnlyChooseOneSector));
    }
}