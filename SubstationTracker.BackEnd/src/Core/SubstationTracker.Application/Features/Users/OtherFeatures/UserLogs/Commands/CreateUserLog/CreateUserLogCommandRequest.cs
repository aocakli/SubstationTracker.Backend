using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Commands.CreateUserLog;

public class CreateUserLogCommandRequest : IRequest<IResponse>
{
    public CreateUserLogCommandRequest(LogType type, string? parameters, bool isSuccess)
    {
        Type = type;
        Parameters = parameters;
        IsSuccess = isSuccess;
    }
    public LogType Type { get; set; }
    public string? Parameters { get; set; }
    public bool IsSuccess { get; set; }
}