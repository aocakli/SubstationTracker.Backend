using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;

public class UserLog : HistoryEntityBase
{
    public UserLog()
    {
    }

    public UserLog(Guid userId, LogType type, string? parameters, bool isSuccess)
    {
        UserId = userId;
        Type = type;
        Parameters = parameters;
        IsSuccess = isSuccess;
    }

    public Guid UserId { get; set; }
    public LogType Type { get; set; }
    public string? Parameters { get; set; }
    public bool IsSuccess { get; set; }

    public virtual User User { get; set; }

    public static UserLog Create(Guid userId, LogType type, string? parameters, bool isSuccess)
    {
        return new UserLog(userId: userId, type: type, parameters: parameters, isSuccess: isSuccess);
    }
}