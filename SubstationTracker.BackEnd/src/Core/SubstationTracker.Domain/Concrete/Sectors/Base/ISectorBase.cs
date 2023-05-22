namespace SubstationTracker.Domain.Concrete.Sectors.Base;

public interface ISectorBase
{
    public string Name { get; set; }
    public string? Description { get; set; }
}