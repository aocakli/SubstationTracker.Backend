using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Products;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Domain.Concrete.Sectors.Base;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;

namespace SubstationTracker.Domain.Concrete.Sectors;

public class Sector : HistoryEntityBase, ISectorBase, ISoftDelete
{
    public Sector()
    {
    }

    public Sector(string name, string? description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsDeleted { get; set; }

    public virtual List<SubstationSector> SubstationSectors { get; set; } = new();
    public virtual List<ProductSector> ProductSectors { get; set; } = new();

    public static Sector Create(string name, string? description)
    {
        return new Sector(name: name, description: description);
    }

    public void Update(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}