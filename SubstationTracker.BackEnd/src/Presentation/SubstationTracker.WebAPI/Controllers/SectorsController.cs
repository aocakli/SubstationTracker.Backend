using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Sectors.Commands.CreateSector;
using SubstationTracker.Application.Features.Sectors.Commands.SoftDeleteSector;
using SubstationTracker.Application.Features.Sectors.Commands.UpdateSector;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("sectors"), AllowAnonymous]
public class SectorsController : ApiControllerBase
{
    public SectorsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetSectorByIdQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));
    
    [HttpPost("get-list")]
    public async Task<IActionResult> GetListAsync(GetSectorsForListQueryRequest request)
        => GenerateResponse(await Mediator.Send(request));

    [HttpPost("create")]
    public async Task<IActionResult> CreateBulkAsync(CreateSectorCommandRequest request)
        => await GenerateResponse(request);

    [HttpPut("update")]
    public async Task<IActionResult> UpdateAsync(UpdateSectorCommandRequest request)
        => await GenerateResponse(request);

    [HttpDelete("soft-delete")]
    public async Task<IActionResult> SoftDeleteAsync([FromQuery] SoftDeleteSectorCommandRequest request)
        => await GenerateResponse(request);
}