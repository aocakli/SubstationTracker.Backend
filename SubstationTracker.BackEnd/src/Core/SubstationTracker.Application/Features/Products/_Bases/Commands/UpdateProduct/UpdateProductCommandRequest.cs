using Microsoft.AspNetCore.Http;

namespace SubstationTracker.Application.Features.Products._Bases.Commands.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
    public HashSet<Guid> SectorIdentities { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public IFormFile? Image { get; set; }
}