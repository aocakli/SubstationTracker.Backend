namespace SubstationTracker.Domain.Abstractions;

public class EntityBase : IEntity
{
    public Guid Id { get; set; }
}