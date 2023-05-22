namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;

public class GetProductQueryRequestValidator : AbstractValidator<GetProductQueryRequest>
{
    public GetProductQueryRequestValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty();
    }
}