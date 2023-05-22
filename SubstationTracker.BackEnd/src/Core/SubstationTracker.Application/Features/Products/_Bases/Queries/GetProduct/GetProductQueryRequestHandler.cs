using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Queries.GetProductSectorsByProduct;
using SubstationTracker.Application.Repositories.Products._Bases;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProduct;

public class
    GetProductQueryRequestHandler : IRequestHandler<GetProductQueryRequest, IDataResponse<GetProductQueryResponse>>
{
    private readonly IProductReadRepository _readRepository;
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;

    public GetProductQueryRequestHandler(IProductReadRepository readRepository, IMediator mediator,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _mediator = mediator;
        _languageService = languageService;
    }

    public async Task<IDataResponse<GetProductQueryResponse>> Handle(GetProductQueryRequest request,
        CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetProductAsync(id: request.Id);
        if (product is null)
            return new ErrorDataResponse<GetProductQueryResponse>(
                message: _languageService.Get(Messages.ProductIsNotFound),
                statusCode: HttpStatusCode.NotFound);

        var productSectorsResult = await _mediator.Send(new GetProductSectorsByProductQueryRequest(productId: product.Id));
        if (productSectorsResult.IsSuccess)
            product.Sectors = productSectorsResult.Data;
        
        return new SuccessDataResponse<GetProductQueryResponse>(
            message: string.Empty,
            data: product);
    }
}