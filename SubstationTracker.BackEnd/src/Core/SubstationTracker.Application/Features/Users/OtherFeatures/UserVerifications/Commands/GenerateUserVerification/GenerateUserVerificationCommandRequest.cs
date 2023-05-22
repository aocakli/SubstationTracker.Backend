using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.GenerateUserVerification;

public class GenerateUserVerificationCommandRequest : IRequest<IDataResponse<UserVerification>>
{
    public GenerateUserVerificationCommandRequest()
    {
    }

    public GenerateUserVerificationCommandRequest(UserVerificationType verificationType)
    {
        VerificationType = verificationType;
    }

    public UserVerificationType VerificationType { get; set; }
}