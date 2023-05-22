using SubstationTracker.Domain.Abstractions;
using SubstationTracker.Domain.Concrete.Products.Base;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Domain.Concrete.Products;

public class Product : HistoryEntityBase, IProductBase
{
    public string Name { get; set; }
    public string PhotoPath { get; set; }
    public string Unit { get; set; }
    public bool IsDeleted { get; set; }

    public virtual List<ProductSector> ProductSectors { get; set; } = new();
    public virtual List<Inventory> Inventories { get; set; } = new();

    public static Product Create(string name, string unit, string photoPath)
    {
        return new Product()
        {
            Name = name,
            Unit = unit,
            PhotoPath = photoPath
        };
    }

    public void Update(string name, string unit, string photoPath)
    {
        Name = name;
        Unit = unit;
        PhotoPath = photoPath;
    }
}