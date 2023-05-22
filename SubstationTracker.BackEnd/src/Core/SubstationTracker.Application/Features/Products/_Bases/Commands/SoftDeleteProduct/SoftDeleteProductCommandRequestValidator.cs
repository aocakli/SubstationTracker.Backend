namespace SubstationTracker.Application.Features.Products._Bases.Commands.SoftDeleteProduct;

public class SoftDeleteProductCommandRequestValidator : AbstractValidator<SoftDeleteProductCommandRequest>
{
    public SoftDeleteProductCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}