using System.Text.Json.Serialization;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Commands.
    AssignResponsiblesToSubstation;

public class AssignResponsiblesToSubstationCommandRequest : IRequest<IResponse>
{
    public AssignResponsiblesToSubstationCommandRequest()
    {
    }

    public AssignResponsiblesToSubstationCommandRequest(HashSet<Guid> userIdentities, Guid substationId,
        bool canTransferTheResponsibleUser, bool isSaveChanges)
    {
        UserIdentities = userIdentities;
        SubstationId = substationId;
        CanTransferTheResponsibleUser = canTransferTheResponsibleUser;
        IsSaveChanges = isSaveChanges;
    }

    public AssignResponsiblesToSubstationCommandRequest(Guid userId, Guid substationId,
        bool canTransferTheResponsibleUser, bool isSaveChanges) : this(userIdentities: new HashSet<Guid>() { userId },
        substationId: substationId,
        canTransferTheResponsibleUser: canTransferTheResponsibleUser,
        isSaveChanges: isSaveChanges)
    {
    }

    public HashSet<Guid> UserIdentities { get; set; }
    public Guid SubstationId { get; set; }

    public bool CanTransferTheResponsibleUser { get; set; }

    [JsonIgnore] public bool IsSaveChanges { get; set; }
}