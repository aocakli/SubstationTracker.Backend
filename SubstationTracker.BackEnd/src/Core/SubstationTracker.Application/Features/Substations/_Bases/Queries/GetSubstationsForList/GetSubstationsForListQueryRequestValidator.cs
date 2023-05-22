using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;

public class GetSubstationsForListQueryRequestValidator : AbstractValidator<GetSubstationsForListQueryRequest>
{
    public GetSubstationsForListQueryRequestValidator()
    {
        RuleFor(x => x.Pagination).NotNull().NotEmpty().SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}