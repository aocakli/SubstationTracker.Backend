namespace SubstationTracker.Domain.Abstractions;

public interface IDocument : IDocumentBase, ISoftDelete
{
    public string Id { get; set; }
}