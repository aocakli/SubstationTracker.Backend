using Microsoft.AspNetCore.Http;

namespace SubstationTracker.Application.Features.Products._Bases.Commands.CreateProduct;

public class CreateProductCommandRequest : IRequest<IDataResponse<CreateProductCommandResponse>>
{
    public HashSet<Guid> SectorIdentities { get; set; } = new();
    public string Name { get; set; }
    public string Unit { get; set; }
    public IFormFile? Image { get; set; }
}