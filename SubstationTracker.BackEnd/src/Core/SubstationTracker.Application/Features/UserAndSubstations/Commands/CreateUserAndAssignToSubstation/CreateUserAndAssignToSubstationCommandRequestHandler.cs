using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.AssignResponsiblesToSubstation;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles.Enums;

namespace SubstationTracker.Application.Features.UserAndSubstations.Commands.CreateUserAndAssignToSubstation;

public class
    CreateUserAndAssignToSubstationCommandRequestHandler : IRequestHandler<CreateUserAndAssignToSubstationCommandRequest
        , IResponse>
{
    private readonly IMediator _mediator;

    public CreateUserAndAssignToSubstationCommandRequestHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResponse> Handle(CreateUserAndAssignToSubstationCommandRequest request,
        CancellationToken cancellationToken)
    {
        request.User.Roles = new HashSet<UserRoleTypes>() { UserRoleTypes.SubstationResponsible };
        request.User.IsSaveChanges = true;
        var createUserResult = await _mediator.Send(request.User);
        if (createUserResult.IsSuccess is false)
            return createUserResult;

        var assignResponsibleToSubstationResult = await _mediator.Send(new AssignResponsiblesToSubstationCommandRequest(
            userId: createUserResult.Data.Id,
            substationId: request.SubstationId,
            canTransferTheResponsibleUser: request.CanForceAssignResponsibleToSubstation,
            isSaveChanges: true));
        if (assignResponsibleToSubstationResult.IsSuccess is false)
            return new ErrorResponse(assignResponsibleToSubstationResult.Message);

        return new SuccessResponse(assignResponsibleToSubstationResult.Message);
    }
}