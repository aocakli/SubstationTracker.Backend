namespace SubstationTracker.Application.Abstracts;

public abstract class DtoBase : IDto
{
    public Guid Id { get; set; }
}