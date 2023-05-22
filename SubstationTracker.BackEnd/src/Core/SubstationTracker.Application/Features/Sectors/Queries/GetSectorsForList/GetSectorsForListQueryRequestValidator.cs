using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;

public class
    GetSectorsForListQueryRequestValidator : AbstractValidator<GetSectorsForListQueryRequest>
{
    public GetSectorsForListQueryRequestValidator()
    {
        RuleFor(x => x.Pagination)
            .NotNull()
            .SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}