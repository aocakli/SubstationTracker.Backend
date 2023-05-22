namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.GetSubstationsByResponsibleUser;

public class
    GetSubstationsByResponsibleUserQueryRequestValidator : AbstractValidator<
        GetSubstationsByResponsibleUserQueryRequest>
{
    public GetSubstationsByResponsibleUserQueryRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
    }
}