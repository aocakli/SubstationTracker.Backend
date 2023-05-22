namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;

public class GetProductsBySubstationQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public string PhotoPath { get; set; }
    public DateTime CreatedDate { get; set; }
}