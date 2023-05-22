using System.Text.Json.Serialization;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications.Enums;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.UserVerifications.Queries.CheckAndVerifyUserVerification;

public class CheckAndVerifyUserVerificationQueryRequest : IRequest<IResponse>
{
    [JsonIgnore] public UserVerificationType VerificationType { get; set; }

    public string Code { get; set; }
}