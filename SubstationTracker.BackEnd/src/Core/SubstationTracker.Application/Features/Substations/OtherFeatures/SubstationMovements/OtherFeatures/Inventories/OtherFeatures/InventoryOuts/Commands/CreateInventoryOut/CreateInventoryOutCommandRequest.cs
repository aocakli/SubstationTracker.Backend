using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories._Bases.Commands.CreateInventory;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryOuts.Commands.
    CreateInventoryOut;

public class CreateInventoryOutCommandRequest : IRequest<IResponse>
{
    public CreateInventoryCommandRequest Inventory { get; set; } = null!;
}