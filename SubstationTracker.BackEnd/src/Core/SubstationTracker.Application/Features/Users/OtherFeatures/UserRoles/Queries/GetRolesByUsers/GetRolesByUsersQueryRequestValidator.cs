namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUsers;

public class GetRolesByUsersQueryRequestValidator : AbstractValidator<GetRolesByUsersQueryRequest>
{
    public GetRolesByUsersQueryRequestValidator()
    {
        RuleFor(x => x.UserIdentities).NotNull().NotEmpty();
    }
}