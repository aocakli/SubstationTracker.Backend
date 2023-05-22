namespace SubstationTracker.Application.Features.Notifications.Abstracts;

public interface INotificationService
{
    public Task<IResponse> SendUserPasswordResetEmailAsync(Guid userId);
}