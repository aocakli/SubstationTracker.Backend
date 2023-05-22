using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;

public class SubstationSector : HistoryEntityBase, ISoftDelete
{
    public SubstationSector(Guid substationId, Guid sectorId)
    {
        SubstationId = substationId;
        SectorId = sectorId;
    }

    public Guid SubstationId { get; set; }
    public Guid SectorId { get; set; }
    public bool IsDeleted { get; set; }

    public virtual Substation? Substation { get; set; }
    public virtual Sector? Sector { get; set; }

    public static SubstationSector Create(Guid substationId, Guid sectorId)
    {
        return new SubstationSector(substationId: substationId, sectorId: sectorId);
    }
}