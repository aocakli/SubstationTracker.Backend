using SubstationTracker.Application.Utilities.Responses.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SubstationTracker.WebAPI.Controllers._Bases;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class ApiControllerBase : ControllerBase
{
    protected IMediator Mediator;

    public ApiControllerBase(IMediator mediator)
    {
        Mediator = mediator;
    }

    [NonAction]
    protected IActionResult GenerateResponse(IResponse response)
    {
        return new JsonResult(response) { StatusCode = (int)response.StatusCode };
    }

    [NonAction]
    protected async Task<IActionResult> GenerateResponse(IRequest<IResponse> request)
    {
        var result = await this.Mediator.Send(request);
        return GenerateResponse(result);
    }
}