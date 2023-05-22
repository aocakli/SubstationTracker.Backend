using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Domain.Abstractions.Audits;

public class CreateAudit : EntityBase
{
    public Guid AuditId { get; set; }
    public Guid? CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    
    public virtual User CreatedUser { get; set; }
    public virtual Audit Audit { get; set; }
}