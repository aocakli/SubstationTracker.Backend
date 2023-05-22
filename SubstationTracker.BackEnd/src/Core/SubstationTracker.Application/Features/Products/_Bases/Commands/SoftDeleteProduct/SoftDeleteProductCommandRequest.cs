namespace SubstationTracker.Application.Features.Products._Bases.Commands.SoftDeleteProduct;

public class SoftDeleteProductCommandRequest : IRequest<IResponse>
{
    public Guid Id { get; set; }
}