namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;

public class GetSubstationByIdQueryRequestValidator : AbstractValidator<GetSubstationByIdQueryRequest>
{
    public GetSubstationByIdQueryRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}