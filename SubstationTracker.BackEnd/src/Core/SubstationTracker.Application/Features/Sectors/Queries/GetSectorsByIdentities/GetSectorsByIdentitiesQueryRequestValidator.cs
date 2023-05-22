namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;

public class GetSectorsByIdentitiesQueryRequestValidator : AbstractValidator<GetSectorsByIdentitiesQueryRequest>
{
    public GetSectorsByIdentitiesQueryRequestValidator()
    {
        RuleFor(x => x.Identities).NotNull().NotEmpty();
    }
}