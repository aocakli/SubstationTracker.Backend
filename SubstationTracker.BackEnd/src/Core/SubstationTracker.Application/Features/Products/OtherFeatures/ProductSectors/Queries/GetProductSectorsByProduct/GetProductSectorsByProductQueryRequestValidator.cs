namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;

public class GetProductSectorsByProductQueryRequestValidator : AbstractValidator<GetProductSectorsByProductQueryRequest>
{
    public GetProductSectorsByProductQueryRequestValidator()
    {
        RuleFor(x => x.ProductId).NotNull().NotEmpty();
    }
}