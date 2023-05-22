using SubstationTracker.Application.Constants;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.AssignResponsiblesToSubstation;

public class
    AssignResponsiblesToSubstationCommandRequestValidator : AbstractValidator<
        AssignResponsiblesToSubstationCommandRequest>
{
    public AssignResponsiblesToSubstationCommandRequestValidator(LanguageService languageService)
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
        RuleFor(x => x.CanTransferTheResponsibleUser).NotNull();

        RuleFor(x => x.UserIdentities)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count is 1)
            .WithMessage(languageService.Get(Messages.YouCanOnlyChooseOneResponsibleUser));
    }
}