using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.BehaviorPipelines.Logs.Attributes;

public class LogTypeAttribute : Attribute
{
    public LogType LogType { get; private set; }
    
    public LogTypeAttribute(LogType logType)
    {
        LogType = logType;
    }
}