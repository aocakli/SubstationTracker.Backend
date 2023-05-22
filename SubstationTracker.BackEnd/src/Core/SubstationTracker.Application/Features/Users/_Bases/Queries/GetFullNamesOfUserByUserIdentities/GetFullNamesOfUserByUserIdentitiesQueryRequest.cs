namespace SubstationTracker.Application.Features.Users._Bases.Queries.GetFullNamesOfUserByUserIdentities;

public class
    GetFullNamesOfUserByUserIdentitiesQueryRequest : IRequest<
        IDataResponse<ICollection<GetFullNamesOfUserByUserIdentitiesQueryResponse>>>
{
    public GetFullNamesOfUserByUserIdentitiesQueryRequest()
    {
    }

    public GetFullNamesOfUserByUserIdentitiesQueryRequest(HashSet<Guid> userIdentities)
    {
        UserIdentities = userIdentities;
    }

    public GetFullNamesOfUserByUserIdentitiesQueryRequest(Guid userId) : this(new HashSet<Guid>() { userId })
    {
    }

    public HashSet<Guid> UserIdentities { get; set; }
}