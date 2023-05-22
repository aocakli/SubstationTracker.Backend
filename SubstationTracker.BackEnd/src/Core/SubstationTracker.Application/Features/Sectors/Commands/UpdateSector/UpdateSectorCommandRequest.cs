using SubstationTracker.Domain.Concrete.Sectors.Base;

namespace SubstationTracker.Application.Features.Sectors.Commands.UpdateSector;

public class UpdateSectorCommandRequest : ISectorBase, IRequest<IResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}