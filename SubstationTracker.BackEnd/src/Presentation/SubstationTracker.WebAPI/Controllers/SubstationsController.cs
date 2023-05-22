using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Sectors.Commands.SoftDeleteSector;
using SubstationTracker.Application.Features.Sectors.Commands.UpdateSector;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;
using SubstationTracker.Application.Features.Substations._Bases.Commands.CreateSubstation;
using SubstationTracker.Application.Features.Substations._Bases.Commands.SoftDeleteSubstation;
using SubstationTracker.Application.Features.Substations._Bases.Commands.UpdateSubstation;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.
    AssignResponsiblesToSubstation;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.GetSubstationsByResponsibleUser;
using SubstationTracker.Application.Features.UserAndSubstations.Commands.CreateUserAndAssignToSubstation;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("substations"), AllowAnonymous]
public class SubstationsController : ApiControllerBase
{
    public SubstationsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetSubstationByIdQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPost("get-list")]
    public async Task<IActionResult> GetListAsync(GetSubstationsForListQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] CreateSubstationCommandRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] UpdateSubstationCommandRequest request)
        => await GenerateResponse(request);

    [HttpPost("assign-responsibles")]
    public async Task<IActionResult> AssignResponsiblesAsync(AssignResponsiblesToSubstationCommandRequest request)
    {
        request.IsSaveChanges = true;
        return await GenerateResponse(request);
    }

    [HttpPost("create-user-and-assign-responsibles")]
    public async Task<IActionResult> CreateUserAndAssignResponsibleAsync(
        CreateUserAndAssignToSubstationCommandRequest request)
        => await GenerateResponse(request);

    [HttpDelete("soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync([FromQuery] SoftDeleteSubstationCommandRequest request)
        => await GenerateResponse(request);
    
    [HttpGet("get-substations-by-responsible-user")]
    public async Task<IActionResult> GetSubstationsByResponsibleUserAsync([FromQuery] GetSubstationsByResponsibleUserQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));
}