namespace SubstationTracker.Domain.Concrete.Substations._Bases.Base;

public interface ISubstationBase
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}