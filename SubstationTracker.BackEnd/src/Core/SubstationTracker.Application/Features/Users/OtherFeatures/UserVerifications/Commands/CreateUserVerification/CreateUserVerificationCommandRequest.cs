using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.CreateUserVerification;

public class CreateUserVerificationCommandRequest : IRequest<IResponse>
{
    public CreateUserVerificationCommandRequest()
    {
    }

    public CreateUserVerificationCommandRequest(Guid userId, UserVerificationType verificationType,
        bool ısSendNotificationToUser)
    {
        UserId = userId;
        VerificationType = verificationType;
        IsSendNotificationToUser = ısSendNotificationToUser;
    }

    public Guid UserId { get; set; }
    public UserVerificationType VerificationType { get; set; }
    public bool IsSendNotificationToUser { get; set; }
}