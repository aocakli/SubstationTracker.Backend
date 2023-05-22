using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Queries.
    GetSubstationMovements;

public class GetSubstationMovementsQueryResponse
{
    public Guid SubstationMovementId { get; set; }
    public DateTime ProcessTime { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PerpetratorUserFullName { get; set; }
    public string MovementType { get; set; }
    public string? Description { get; set; }
    public decimal Quantity { get; set; }
    public string Unit { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal AvailablePrice { get; set; }
    public decimal AvailableQuantity { get; set; }

    public static GetSubstationMovementsQueryResponse CreateStockEntry(SubstationMovement substationMovement,
        string movementType, decimal availablePrice, decimal availableQuantity)
    {
        return new GetSubstationMovementsQueryResponse()
        {
            SubstationMovementId = substationMovement.Id,
            ProcessTime = substationMovement.ProcessTime,
            CreatedDate = substationMovement.Audit!.CreateAudit!.CreatedDate,
            PerpetratorUserFullName = substationMovement.Audit.CreateAudit.CreatedUser?.FullName ?? "Bilinmiyor",
            MovementType = movementType,
            Description =
                $"Ürün: {substationMovement.Inventory!.ProductName}{(substationMovement.Inventory.Description is not null ? " - " + substationMovement.Inventory.Description : string.Empty)}",
            Quantity = substationMovement.Inventory.Quantity,
            Unit = substationMovement.Inventory.Unit,
            TotalPrice = substationMovement.Inventory.TotalPrice,
            AvailablePrice = availablePrice,
            AvailableQuantity = availableQuantity
        };
    }
}