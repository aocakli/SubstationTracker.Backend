namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Commands.CreateSubstationMovement;

public class CreateSubstationMovementCommandResponse
{
    public CreateSubstationMovementCommandResponse(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}