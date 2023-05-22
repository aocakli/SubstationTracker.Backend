using MediatR;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Queries.GetSubstationMovements;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryEntries.Commands.CreateInventoryEntry;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryOuts.Commands.CreateInventoryOut;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("substation-movements")]
public class SubstationMovementsController : ApiControllerBase
{
    public SubstationMovementsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("inventory/create-inventory-entry")]
    public async Task<IActionResult> CreateInventoryEntryAsync(CreateInventoryEntryCommandRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("inventory/create-inventory-out")]
    public async Task<IActionResult> CreateInventoryOutAsync(CreateInventoryOutCommandRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }
    
    [HttpPost("get-movements-by-substation")]
    public async Task<IActionResult> GetMovementsBySubstationAsync(GetSubstationMovementsQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }
}