namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Dtos;

public class CreateSubstationMovementDto
{
    public Guid SubstationId { get; set; }
    public DateTime ProcessTime { get; set; }
}