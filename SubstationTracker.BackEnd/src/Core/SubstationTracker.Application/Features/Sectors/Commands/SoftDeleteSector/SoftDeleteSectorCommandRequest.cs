namespace SubstationTracker.Application.Features.Sectors.Commands.SoftDeleteSector;

public class SoftDeleteSectorCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
}