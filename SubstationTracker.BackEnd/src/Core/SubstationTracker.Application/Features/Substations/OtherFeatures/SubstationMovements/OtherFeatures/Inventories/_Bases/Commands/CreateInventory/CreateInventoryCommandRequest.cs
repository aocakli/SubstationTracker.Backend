using System.Text.Json.Serialization;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Dtos;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories
    ._Bases.Commands.CreateInventory;

public class CreateInventoryCommandRequest : CreateSubstationMovementDto,
    IRequest<IDataResponse<CreateInventoryCommandResponse>>
{
    public Guid ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public string? Description { get; set; }


    [JsonIgnore] public bool IsSaveChanges { get; set; }
}