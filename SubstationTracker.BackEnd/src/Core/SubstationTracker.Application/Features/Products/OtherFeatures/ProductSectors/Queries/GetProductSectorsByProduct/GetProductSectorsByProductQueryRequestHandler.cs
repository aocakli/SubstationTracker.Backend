using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Products.ProductSectors;

namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.
    GetProductSectorsByProduct;

public class
    GetProductSectorsByProductQueryRequestHandler : IRequestHandler<GetProductSectorsByProductQueryRequest,
        IDataResponse<ICollection<GetProductSectorsByProductQueryResponse>>>
{
    private readonly IProductSectorReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetProductSectorsByProductQueryRequestHandler(IProductSectorReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<ICollection<GetProductSectorsByProductQueryResponse>>> Handle(
        GetProductSectorsByProductQueryRequest request,
        CancellationToken cancellationToken)
    {
        var productSectors = await _readRepository.GetProductSectorsByProductAsync(productId: request.ProductId);
        if (productSectors.Any() is false)
            return new ErrorDataResponse<ICollection<GetProductSectorsByProductQueryResponse>>(
                message: _languageService.Get(Messages.ProductSectorsAreNotFound));

        return new SuccessDataResponse<ICollection<GetProductSectorsByProductQueryResponse>>(
            message: _languageService.Get(Messages.ProductSectorsAreListed),
            data: productSectors);
    }
}