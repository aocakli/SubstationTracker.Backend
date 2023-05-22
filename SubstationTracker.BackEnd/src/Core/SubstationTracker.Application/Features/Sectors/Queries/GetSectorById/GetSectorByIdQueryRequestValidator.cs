namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;

public class GetSectorByIdQueryRequestValidator : AbstractValidator<GetSectorByIdQueryRequest>
{
    public GetSectorByIdQueryRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}