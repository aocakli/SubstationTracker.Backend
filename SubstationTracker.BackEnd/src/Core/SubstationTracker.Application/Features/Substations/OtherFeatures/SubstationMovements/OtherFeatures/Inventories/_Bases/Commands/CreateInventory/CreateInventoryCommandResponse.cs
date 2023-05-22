namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories._Bases.Commands.CreateInventory;

public class CreateInventoryCommandResponse
{
    public CreateInventoryCommandResponse(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}