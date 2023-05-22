using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Queries.GetSubstationMovements;

public class
    GetSubstationMovementsQueryRequestValidator : AbstractValidator<
        GetSubstationMovementsQueryRequest>
{
    public GetSubstationMovementsQueryRequestValidator()
    {
        RuleFor(x => x.SubstationId).NotEmpty().When(x => x.SubstationId.HasValue);

        RuleFor(x => x.Pagination).NotNull().SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}