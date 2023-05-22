using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Domain.Concrete.Sectors;
using SubstationTracker.Domain.Concrete.Substations;
using SubstationTracker.Domain.Concrete.Substations._Bases;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationResponsibleUsers;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;
using SubstationTracker.Domain.Concrete.Users._Bases;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserLogs;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserRoles;
using SubstationTracker.Domain.Concrete.Users.OtherDomains.UserVerifications;

namespace SubstationTracker.Domain.Abstractions.Audits;

public class Audit : EntityBase, IAudit
{
    public string Table { get; set; }

    public virtual CreateAudit? CreateAudit { get; set; }
    public virtual List<UpdateAudit> UpdateAudits { get; set; } = new();
    public virtual DeleteAudit? DeleteAudit { get; set; }


    public virtual User? User { get; set; }
    public virtual UserVerification? UserVerification { get; set; }
    public virtual UserRole? UserRole { get; set; }
    public virtual UserLog? UserLog { get; set; }
    
    public virtual Sector? Sector { get; set; }
    public virtual Substation? Substation { get; set; }
    public virtual SubstationSector? SubstationSector { get; set; }
    public virtual SubstationResponsibleUser? SubstationResponsibleUser { get; set; }
    public virtual Product? Product { get; set; }
    public virtual ProductSector? ProductSector { get; set; }
    
    public virtual SubstationMovement? SubstationMovement { get; set; }
    public virtual Inventory? Inventory { get; set; }
    public virtual InventoryEntry? InventoryEntry { get; set; }
    public virtual InventoryOut? InventoryOut { get; set; }
}