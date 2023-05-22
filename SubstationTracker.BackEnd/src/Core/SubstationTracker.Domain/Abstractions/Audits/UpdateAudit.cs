using SubstationTracker.Domain.Concrete.Users._Bases;

namespace SubstationTracker.Domain.Abstractions.Audits;

public class UpdateAudit : EntityBase
{
    public Guid AuditId { get; set; }
    public Guid? UpdatedById { get; set; }
    public DateTime UpdatedDate { get; set; }
    public string BeforeColumnData { get; set; }
    public string AfterColumnData { get; set; }
    
    public virtual User UpdatedUser { get; set; }
    public virtual Audit Audit { get; set; }
}