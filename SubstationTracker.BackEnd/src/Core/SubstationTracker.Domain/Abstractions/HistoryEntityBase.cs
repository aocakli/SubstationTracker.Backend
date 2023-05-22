using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Domain.Abstractions;

public class HistoryEntityBase : EntityBase, IHistoryEntity
{
    public Guid AuditId { get; set; }

    public virtual Audit? Audit { get; set; }
}