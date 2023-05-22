using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;

public class SubstationResponsibleUser : HistoryEntityBase, ISoftDelete
{
    public SubstationResponsibleUser()
    {
    }

    public SubstationResponsibleUser(Guid substationId, Guid responsibleUserId)
    {
        SubstationId = substationId;
        ResponsibleUserId = responsibleUserId;
    }

    public Guid SubstationId { get; set; }
    public Guid ResponsibleUserId { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Substation? Substation { get; set; }
    public virtual User? ResponsibleUser { get; set; }

    public static SubstationResponsibleUser Create(Guid substationId, Guid responsibleUserId)
    {
        return new SubstationResponsibleUser(substationId: substationId, responsibleUserId: responsibleUserId);
    }
}