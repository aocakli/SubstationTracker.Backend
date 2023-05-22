using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Domain.Abstractions.Audits;

public class DeleteAudit : EntityBase
{
    public Guid AuditId { get; set; }
    public Guid? DeletedById { get; set; }
    public DateTime DeletedDate { get; set; }
    
    public virtual User DeletedUser { get; set; }
    public virtual Audit Audit { get; set; }
}