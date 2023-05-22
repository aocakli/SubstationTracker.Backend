namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.CreateSectorsToProduct;

public class CreateSectorsToProductQueryRequestValidator : AbstractValidator<CreateSectorsToProductQueryRequest>
{
    public CreateSectorsToProductQueryRequestValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();

        RuleFor(x => x.SectorIdentities)
            .NotNull()
            .NotEmpty()
            .Must(x => x.Count is 1);
    }
}