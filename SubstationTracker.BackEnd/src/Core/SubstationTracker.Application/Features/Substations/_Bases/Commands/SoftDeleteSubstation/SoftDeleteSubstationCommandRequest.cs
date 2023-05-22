namespace SubstationTracker.Application.Features.Substations._Bases.Commands.SoftDeleteSubstation;

public class SoftDeleteSubstationCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
}