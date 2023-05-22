using SubstationTracker.Domain.Concrete.Sectors.Base;

namespace SubstationTracker.Application.Features.Sectors.Commands.CreateSector;

public class CreateSectorCommandRequest : ISectorBase, IRequest<IResponse>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}