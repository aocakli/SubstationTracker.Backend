using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;
using SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Commands.GenerateUserVerification;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Mappings;

public class UserVerificationMappings : Profile
{
    public UserVerificationMappings()
    {
        CreateMap<GenerateUserVerificationCommandRequest, UserVerification>();
    }
}