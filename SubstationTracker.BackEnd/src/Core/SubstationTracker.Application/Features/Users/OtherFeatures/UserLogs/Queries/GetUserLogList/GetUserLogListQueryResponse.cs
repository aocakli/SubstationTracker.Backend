using SubstationTracker.Application.Helpers;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs.Enums;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserLogs.Queries.GetUserLogList;

public class GetUserLogListQueryResponse
{
    public GetUserLogListQueryResponse(Guid id, Guid userId, string userFullName, LogType type, string? parameters,
        bool isSuccess, DateTime createdDate)
    {
        Id = id;
        UserId = userId;
        UserFullName = userFullName;
        Type = type;
        Parameters = parameters;
        IsSuccess = isSuccess;
        CreatedDate = createdDate;
    }

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string UserFullName { get; set; }
    public LogType Type { get; set; }
    public string? Parameters { get; set; }
    public bool IsSuccess { get; set; }
    public DateTime CreatedDate { get; set; }

    public string Message =>
        $"{UserFullName}, {WordHelper.CamelCaseToWhiteSpaceSplit(Type.ToString())} işlemini başlattı ve işlemi {(IsSuccess ? "Başarıyla tamamladı." : "tamamlayamadı.")}";
}