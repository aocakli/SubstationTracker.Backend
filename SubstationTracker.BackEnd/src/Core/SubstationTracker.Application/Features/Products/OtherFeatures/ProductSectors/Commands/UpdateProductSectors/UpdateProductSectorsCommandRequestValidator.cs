namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.UpdateProductSectors;

public class UpdateProductSectorsCommandRequestValidator : AbstractValidator<UpdateProductSectorsCommandRequest>
{
    public UpdateProductSectorsCommandRequestValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
        RuleFor(x => x.SectorIdentities)
            .NotNull()
            .NotEmpty();
    }
}