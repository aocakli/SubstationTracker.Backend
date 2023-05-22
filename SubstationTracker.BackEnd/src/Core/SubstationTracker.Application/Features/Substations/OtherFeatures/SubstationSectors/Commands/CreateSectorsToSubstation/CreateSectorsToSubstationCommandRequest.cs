using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.Commands.CreateSectorsToSubstation;

public class CreateSectorsToSubstationCommandRequest : IRequest<IResponse>
{
    public CreateSectorsToSubstationCommandRequest(Guid substationId, HashSet<Guid> sectorIdentities, bool isSaveChanges)
    {
        SubstationId = substationId;
        SectorIdentities = sectorIdentities;
        IsSaveChanges = isSaveChanges;
    }
    public Guid SubstationId { get; set; }
    public HashSet<Guid> SectorIdentities { get; set; }
    
    [JsonIgnore] public bool IsSaveChanges { get; set; }
}