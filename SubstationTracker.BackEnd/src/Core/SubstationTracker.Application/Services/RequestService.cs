using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;

namespace SubstationTracker.Application.Services;

public class RequestService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMediator _mediator;

    public Guid? PerpetratorUserId { get; set; }
    public string FullName { get; set; } = "Unknown";

    public RequestService(IHttpContextAccessor httpContextAccessor, IMediator mediator)
    {
        _httpContextAccessor = httpContextAccessor;
        _mediator = mediator;

        GetPerpetratorUserId();

        GetFullNameOfUser();
    }

    private void GetPerpetratorUserId()
    {
        var id = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(_claim =>
            _claim.Type.Equals(ClaimTypes.NameIdentifier))?.Value ?? string.Empty;

        if (Guid.TryParse(id, out Guid idAsGuid))
            PerpetratorUserId = idAsGuid;
    }

    public void GetFullNameOfUser()
    {
        if (PerpetratorUserId.HasValue is false)
            return;

        var fullNameResult = _mediator.Send(new GetFullNamesOfUserByUserIdentitiesQueryRequest(PerpetratorUserId.Value))
            .Result;
        if (fullNameResult.IsSuccess is false)
            return;

        FullName = fullNameResult.Data.First().FullName;
    }
}