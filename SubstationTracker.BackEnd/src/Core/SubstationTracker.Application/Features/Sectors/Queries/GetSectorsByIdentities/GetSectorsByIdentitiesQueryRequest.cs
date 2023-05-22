namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;

public class
    GetSectorsByIdentitiesQueryRequest : IRequest<IDataResponse<ICollection<GetSectorsByIdentitiesQueryResponse>>>
{
    public GetSectorsByIdentitiesQueryRequest()
    {
    }
    public GetSectorsByIdentitiesQueryRequest(HashSet<Guid> identities)
    {
        Identities = identities;
    }
    public HashSet<Guid> Identities { get; set; }
}