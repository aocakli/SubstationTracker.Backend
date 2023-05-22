using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;

public class GetProductsBySubstationQueryRequestValidator : AbstractValidator<GetProductsBySubstationQueryRequest>
{
    public GetProductsBySubstationQueryRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
        RuleFor(x => x.Pagination)
            .NotNull()
            .NotEmpty()
            .SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}