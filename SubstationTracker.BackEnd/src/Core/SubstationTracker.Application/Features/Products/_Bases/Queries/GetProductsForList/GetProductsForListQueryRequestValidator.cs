using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;

public class GetProductsForListQueryRequestValidator : AbstractValidator<GetProductsForListQueryRequest>
{
    public GetProductsForListQueryRequestValidator()
    {
        RuleFor(x => x.Pagination)
            .NotNull()
            .NotEmpty()
            .SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}