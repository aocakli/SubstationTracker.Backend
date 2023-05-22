namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.CreateSubstationResponsibleUsers;

public class CreateSubstationResponsibleUserCommandRequestValidator : AbstractValidator<CreateSubstationResponsibleUserCommandRequest>
{
    public CreateSubstationResponsibleUserCommandRequestValidator()
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
        RuleFor(x => x.ResponsibleUserId).NotNull().NotEmpty();
    }
}