using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

public class InventoryOut : HistoryEntityBase
{
    public virtual Inventory Inventory { get; set; }

    public static InventoryOut Create(Guid inventoryId)
    {
        return new InventoryOut()
        {
            Id = inventoryId
        };
    }
}