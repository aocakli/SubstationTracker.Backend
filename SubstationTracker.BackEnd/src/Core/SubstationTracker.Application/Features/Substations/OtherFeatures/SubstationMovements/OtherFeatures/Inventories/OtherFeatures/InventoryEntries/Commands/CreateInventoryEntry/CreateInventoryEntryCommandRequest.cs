using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories._Bases.Commands.CreateInventory;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryEntries.Commands.
    CreateInventoryEntry;

public class CreateInventoryEntryCommandRequest : IRequest<IResponse>
{
    public CreateInventoryCommandRequest Inventory { get; set; } = null!;
}