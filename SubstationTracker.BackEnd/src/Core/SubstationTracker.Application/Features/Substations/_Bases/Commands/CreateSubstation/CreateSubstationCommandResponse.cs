namespace SubstationTracker.Application.Features.Substations._Bases.Commands.CreateSubstation;

public class CreateSubstationCommandResponse
{
    public CreateSubstationCommandResponse(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}