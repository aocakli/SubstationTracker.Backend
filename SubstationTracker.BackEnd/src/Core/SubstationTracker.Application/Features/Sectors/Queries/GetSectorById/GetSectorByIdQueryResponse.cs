using SubstationTracker.Domain.Concrete.Sectors.Base;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;

public class GetSectorByIdQueryResponse : ISectorBase
{
    public GetSectorByIdQueryResponse(Guid id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public static GetSectorByIdQueryResponse Create(Guid id, string name, string? description)
    {
        return new GetSectorByIdQueryResponse(id: id, name: name, description: description);
    }
}