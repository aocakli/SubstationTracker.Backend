using SubstationTracker.Application.BehaviorPipelines.Transaction.Enums;
using SubstationTracker.Application.Features.Users._Bases.Commands.CreateUser;

namespace SubstationTracker.Application.Features.UserAndSubstations.Commands.CreateUserAndAssignToSubstation;

[UseTransaction]
public class CreateUserAndAssignToSubstationCommandRequest : IRequest<IResponse>
{
    public Guid SubstationId { get; set; }
    public bool CanForceAssignResponsibleToSubstation { get; set; }
    public CreateUserCommandRequest User { get; set; }
}