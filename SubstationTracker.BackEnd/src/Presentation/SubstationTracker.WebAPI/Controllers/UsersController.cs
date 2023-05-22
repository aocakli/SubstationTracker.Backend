using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserById;
using SubstationTracker.Application.Features.Users._Bases.Queries.LoginUser;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Commands.CreateUserResetPassword;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserResetPasswords.Queries.
    CheckResetPasswordCodeAndResetPassword;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserTokens._Bases.Queries.GetUserTokensByRefreshToken;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Queries.
    CheckAndVerifyUserVerification;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUserList;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.WebAPI.Controllers._Bases;

namespace SubstationTracker.WebAPI.Controllers;

[Route("users")]
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(IMediator mediator, ILogger<UsersController> logger) : base(mediator)
    {
        _logger = logger;
    }

    [HttpPost("get-user-list"), Authorize(Roles = AuthRoles.Admin)]
    public async Task<IActionResult> GetUserListsAsync(GetUserListQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpGet("get-user-by-id")]
    public async Task<IActionResult> GetUserListsAsync([FromQuery] GetUserByIdQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("send-reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> SendResetPasswordCodeAsync(CreateUserResetPasswordCommandRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("check-and-reset-password")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckResetPasswordCodeAsync(
        CheckResetPasswordCodeAndResetPasswordQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> LoginAsync(LoginUserQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("check-and-verify-for-email")]
    [AllowAnonymous]
    public async Task<IActionResult> CheckAndVerifyForEmailAsync(CheckAndVerifyUserVerificationQueryRequest request)
    {
        request.VerificationType = UserVerificationType.Email;
        return GenerateResponse(await Mediator.Send(request));
    }

    [HttpPost("get-user-tokens-with-refresh-token")]
    [AllowAnonymous]
    public async Task<IActionResult> GetUserTokensWithRefreshTokenAsync(GetUserTokensByRefreshTokenQueryRequest request)
    {
        return GenerateResponse(await Mediator.Send(request));
    }
}