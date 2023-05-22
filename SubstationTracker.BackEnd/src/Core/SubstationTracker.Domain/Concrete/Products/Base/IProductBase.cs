using SubstationTracker.Domain.Abstractions;

namespace SubstationTracker.Domain.Concrete.Products.Base;

public interface IProductBase : ISoftDelete
{
    public string Name { get; set; }
    public string PhotoPath { get; set; }
    public string Unit { get; set; }
}