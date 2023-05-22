namespace SubstationTracker.Application.Features.Products._Bases.Commands.UpdateProduct;

public class UpdateProductCommandRequestValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
        RuleFor(x => x.Name).NotNull().NotEmpty();
        RuleFor(x => x.Unit).NotNull().NotEmpty();
        RuleFor(x => x.Image);
        
        RuleFor(x => x.SectorIdentities).NotNull().NotEmpty();
    }
}