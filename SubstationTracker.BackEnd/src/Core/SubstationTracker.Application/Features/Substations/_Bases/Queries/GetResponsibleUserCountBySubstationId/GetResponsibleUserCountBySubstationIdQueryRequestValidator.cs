namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetResponsibleUserCountBySubstationId;

public class GetResponsibleUserCountBySubstationIdQueryRequestValidator : AbstractValidator<GetResponsibleUserCountBySubstationIdQueryRequest>
{
    public GetResponsibleUserCountBySubstationIdQueryRequestValidator()
    {
        RuleFor(x => x.SubstationId).NotNull().NotEmpty();
    }
}