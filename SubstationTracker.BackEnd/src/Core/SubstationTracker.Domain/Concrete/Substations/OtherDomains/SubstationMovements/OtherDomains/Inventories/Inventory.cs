using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Products;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

public class Inventory : HistoryEntityBase
{
    public Guid SubstationMovementId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string Unit { get; set; }
    public string? Description { get; set; }

    public virtual Product? Product { get; set; }
    public virtual InventoryEntry? InventoryEntry { get; set; }
    public virtual InventoryOut? InventoryOut { get; set; }
    public virtual SubstationMovement? SubstationMovement { get; set; }

    public static Inventory Create(Guid substationMovementId, Guid productId, string productName, decimal quantity,
        decimal totalPrice, string unit, string? description)
    {
        return new Inventory()
        {
            SubstationMovementId = substationMovementId,
            ProductId = productId,
            ProductName = productName,
            Quantity = quantity,
            TotalPrice = totalPrice,
            Unit = unit,
            Description = description
        };
    }
}