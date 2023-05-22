using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Features.Users.OtherFeatures.Admins.Queries.GetAdminEmailAddresses;

public class GetAdminEmailAddressesQueryRequest : IRequest<IDataResponse<HashSet<string>>>
{
}