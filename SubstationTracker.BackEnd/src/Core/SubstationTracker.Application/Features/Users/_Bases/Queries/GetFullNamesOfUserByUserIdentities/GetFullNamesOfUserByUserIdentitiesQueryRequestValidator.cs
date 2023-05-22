namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;

public class
    GetFullNamesOfUserByUserIdentitiesQueryRequestValidator : AbstractValidator<
        GetFullNamesOfUserByUserIdentitiesQueryRequest>
{
    public GetFullNamesOfUserByUserIdentitiesQueryRequestValidator()
    {
        RuleFor(x => x.UserIdentities).NotNull().NotEmpty();
    }
}