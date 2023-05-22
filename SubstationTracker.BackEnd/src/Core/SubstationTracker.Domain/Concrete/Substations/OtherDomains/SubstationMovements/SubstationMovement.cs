using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

public class SubstationMovement : HistoryEntityBase, ISoftDelete
{
    public Guid SubstationId { get; set; }
    public DateTime ProcessTime { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Substation? Substation { get; set; }
    public virtual Inventory? Inventory { get; set; }

    public static SubstationMovement Create(Guid substationId, DateTime processTime)
    {
        return new SubstationMovement()
        {
            SubstationId = substationId,
            ProcessTime = processTime
        };
    }
}