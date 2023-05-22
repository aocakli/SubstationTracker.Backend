using SubstationTracker.Domain.Concrete.Sectors.Base;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;

public class GetSectorsByIdentitiesQueryResponse : ISectorBase
{
    public GetSectorsByIdentitiesQueryResponse()
    {
    }

    public GetSectorsByIdentitiesQueryResponse(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }


    public static GetSectorsByIdentitiesQueryResponse Create(Guid id, string name, string? description)
    {
        return new GetSectorsByIdentitiesQueryResponse(id: id, name: name, description: description);
    }
}