namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;

public class GetProductsForListQueryResponse
{
    public Guid Id { get; set; }
    public HashSet<string> SectorNames { get; set; } = new();
    public string Name { get; set; }
    public string Unit { get; set; }
    public string PhotoPath { get; set; }
    public DateTime CreatedDate { get; set; }
}