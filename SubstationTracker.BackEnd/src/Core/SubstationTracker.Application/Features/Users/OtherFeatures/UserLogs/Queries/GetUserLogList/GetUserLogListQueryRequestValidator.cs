using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;

public class GetUserLogListQueryRequestValidator : AbstractValidator<GetUserLogListQueryRequest>
{
    public GetUserLogListQueryRequestValidator()
    {
        RuleFor(x => x.Type)
            .NotEmpty()
            .NotEqual(LogType.Unknown)
            .When(x => x.Type.HasValue);
        
        RuleFor(x => x.UserId)
            .NotEmpty()
            .When(x => x.UserId.HasValue);
        
        RuleFor(x => x.Pagination).NotNull().SetValidator(new InlineValidator<PaginationRequestBase>());
    }
}