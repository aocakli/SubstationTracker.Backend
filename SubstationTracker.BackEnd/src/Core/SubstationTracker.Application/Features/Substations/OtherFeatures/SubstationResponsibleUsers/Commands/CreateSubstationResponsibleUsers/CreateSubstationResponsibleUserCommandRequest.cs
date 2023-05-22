using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.CreateSubstationResponsibleUsers;

public class CreateSubstationResponsibleUserCommandRequest : IRequest<IResponse>
{
    public CreateSubstationResponsibleUserCommandRequest()
    {
    }
    public CreateSubstationResponsibleUserCommandRequest(Guid substationId, Guid responsibleUserId, bool checkBusinessRules, bool isSaveChanges)
    {
        SubstationId = substationId;
        ResponsibleUserId = responsibleUserId;
        CheckBusinessRules = checkBusinessRules;
        IsSaveChanges = isSaveChanges;
    }
    public Guid SubstationId { get; set; }
    public Guid ResponsibleUserId { get; set; }

    public bool CheckBusinessRules { get; set; }
    
    [JsonIgnore] public bool IsSaveChanges { get; set; }
}