namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserRoles.Queries.GetRolesByUserId;

public class GetRolesByUserIdQueryRequestValidator : AbstractValidator<GetRolesByUserIdQueryRequest>
{
    public GetRolesByUserIdQueryRequestValidator()
    {
        RuleFor(x => x.UserId).NotNull().NotEmpty();
    }
}