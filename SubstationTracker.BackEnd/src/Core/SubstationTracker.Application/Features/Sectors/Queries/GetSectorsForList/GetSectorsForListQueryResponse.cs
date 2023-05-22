using SubstationTracker.Domain.Concrete.Sectors.Base;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;

public class GetSectorsForListQueryResponse : ISectorBase
{
    public GetSectorsForListQueryResponse(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public static GetSectorsForListQueryResponse Create(Guid id, string name, string? description)
    {
        return new GetSectorsForListQueryResponse(id: id, name: name, description: description);
    }
}