using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.BusinessRules;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;

namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.CreateSectorsToProduct;

public class CreateSectorsToProductQueryRequestHandler : IRequestHandler<CreateSectorsToProductQueryRequest, IResponse>
{
    private readonly IProductSectorWriteRepository _writeRepository;
    private readonly ProductSectorBusinessRules _businessRules;
    private readonly LanguageService _languageService;

    public CreateSectorsToProductQueryRequestHandler(IProductSectorWriteRepository writeRepository,
        ProductSectorBusinessRules businessRules, LanguageService languageService)
    {
        _writeRepository = writeRepository;
        _businessRules = businessRules;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CreateSectorsToProductQueryRequest request,
        CancellationToken cancellationToken)
    {
        await _businessRules.ProductSectorsAreShouldAlreadyNotExistInProductAsync(productId: request.ProductId,
            sectorIdentities: request.SectorIdentities);

        List<ProductSector> productSectorsToAdd = request.SectorIdentities
            .Select(_sectorId => ProductSector.Create(productId: request.ProductId, sectorId: _sectorId))
            .ToList();

        await _writeRepository.CreateBulkAsync(productSectorsToAdd);

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SectorsAreNotAddedToProduct));

        return new SuccessResponse(message: _languageService.Get(Messages.SectorsAreAddedToProduct),
            statusCode: HttpStatusCode.Created);
    }
}