namespace SubstationTracker.Application.Features.Products._Bases.Commands.CreateProduct;

public class CreateProductCommandResponse
{
    public CreateProductCommandResponse(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}