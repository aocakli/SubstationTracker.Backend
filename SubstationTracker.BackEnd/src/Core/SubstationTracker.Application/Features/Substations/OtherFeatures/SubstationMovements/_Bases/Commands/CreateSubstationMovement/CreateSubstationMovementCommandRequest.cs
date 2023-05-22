using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Commands.CreateSubstationMovement;

public class CreateSubstationMovementCommandRequest : IRequest<IDataResponse<CreateSubstationMovementCommandResponse>>
{
    public CreateSubstationMovementCommandRequest()
    {
        
    }

    public CreateSubstationMovementCommandRequest(Guid substationId, DateTime processTime,bool isSaveChanges)
    {
        SubstationId = substationId;
        ProcessTime = processTime;
        IsSaveChanges = isSaveChanges;
    }
    public Guid SubstationId { get; set; }
    public DateTime ProcessTime { get; set; }    
    [JsonIgnore] public bool IsSaveChanges { get; set; }
}