namespace SubstationTracker.Application.Features.Products._Bases.Commands.CreateProduct;

public class CreateProductCommandRequestValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductCommandRequestValidator()
    {
        RuleFor(x => x.Name).NotNull().NotEmpty();

        RuleFor(x => x.Unit).NotNull().NotEmpty();

        RuleFor(x => x.Image);

        RuleFor(x => x.SectorIdentities).NotNull().NotEmpty();
    }
}