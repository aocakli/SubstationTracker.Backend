using SubstationTracker.Application.Features.Users._Bases.Dtos;

namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;

public class GetUsersByIdentitiesQueryRequest : IRequest<IDataResponse<ICollection<UserDto>>>
{
    public GetUsersByIdentitiesQueryRequest()
    {
    }

    public GetUsersByIdentitiesQueryRequest(HashSet<Guid> identities)
    {
        Identities = identities;
    }

    public GetUsersByIdentitiesQueryRequest(Guid id) : this(new HashSet<Guid> { id })
    {
    }

    public HashSet<Guid> Identities { get; set; }
}