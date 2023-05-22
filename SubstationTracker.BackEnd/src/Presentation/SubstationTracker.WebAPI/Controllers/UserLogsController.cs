using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("user-logs")]
public class UserLogsController : ApiControllerBase
{
    public UserLogsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("get-log-list")]
    [Authorize(Roles = AuthRoles.Admin)]
    public async Task<IActionResult> GetLogList(GetUserLogListQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }
}