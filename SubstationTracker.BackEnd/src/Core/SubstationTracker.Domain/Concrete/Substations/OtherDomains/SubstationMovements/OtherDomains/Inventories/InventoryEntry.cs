using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

public class InventoryEntry : HistoryEntityBase
{
    public virtual Inventory? Inventory { get; set; }

    public static InventoryEntry Create(Guid inventoryId)
    {
        return new InventoryEntry()
        {
            Id = inventoryId
        };
    }
}