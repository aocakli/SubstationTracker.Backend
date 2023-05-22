using SubstationTracker.Domain.Abstractions.Audits;

namespace SubstationTracker.Domain.Abstractions;

public interface IHistoryEntity : IEntity
{
    public Guid AuditId { get; set; }

    public Audit? Audit { get; set; }
}