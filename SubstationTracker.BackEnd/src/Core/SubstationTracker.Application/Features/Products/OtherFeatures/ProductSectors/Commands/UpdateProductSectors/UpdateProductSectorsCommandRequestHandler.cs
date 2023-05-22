using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Products.OtherDomains;

namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.UpdateProductSectors;

public class UpdateProductSectorsCommandRequestHandler : IRequestHandler<UpdateProductSectorsCommandRequest, IResponse>
{
    private readonly IProductSectorReadRepository _readRepository;
    private readonly IProductSectorWriteRepository _writeRepository;
    private readonly LanguageService _languageService;

    public UpdateProductSectorsCommandRequestHandler(IProductSectorReadRepository readRepository,
        IProductSectorWriteRepository writeRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(UpdateProductSectorsCommandRequest request, CancellationToken cancellationToken)
    {
        var productSectors = await _readRepository.GetAllAsync(
            exp: _productSector => _productSector.ProductId.Equals(request.ProductId),
            features: new RepoFeatures(includeAudit: true, noTracking: false));

        #region Remove

        var sectorIdentitiesToRemove = FindWillBeRemove(request, productSectors);

        var productSectorsToRemove = productSectors.Where(_productSector =>
                _productSector.ProductId.Equals(request.ProductId) &&
                sectorIdentitiesToRemove.Contains(_productSector.SectorId))
            .ToList();
        foreach (var productSectorToRemove in productSectorsToRemove)
            await _writeRepository.SoftDeleteAsync(productSectorToRemove);

        foreach (var productSectorToRemove in sectorIdentitiesToRemove)
        {
            var canDeleteProductSectors = productSectors
                .Where(_productSector => productSectorToRemove.Equals(_productSector.SectorId) &&
                                         _productSector.ProductId.Equals(request.ProductId));

            foreach (var productSector in canDeleteProductSectors)
                await _writeRepository.SoftDeleteAsync(productSector);
        }

        #endregion

        #region Add

        var sectorIdentitiesToAdd = FindWillBeAdds(request, productSectors);

        List<ProductSector> productSectorsToAdd = sectorIdentitiesToAdd
            .Select(_sectorId => ProductSector.Create(productId: request.ProductId, sectorId: _sectorId))
            .ToList();

        if (productSectorsToAdd.Any())
            await _writeRepository.CreateBulkAsync(productSectorsToAdd);

        #endregion

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ProductSectorsAreNotUpdated));

        return new SuccessResponse(message: _languageService.Get(Messages.ProductSectorsAreUpdated));
    }

    private HashSet<Guid> FindWillBeRemove(UpdateProductSectorsCommandRequest request,
        ICollection<ProductSector> productSectors)
    {
        HashSet<Guid> productSectorsToRemove = new();
        foreach (var productSector in productSectors)
        {
            Guid sectorId = productSector.SectorId;

            bool isExist = request.SectorIdentities.Any(_sectorId => _sectorId.Equals(sectorId));
            if (isExist)
                continue;

            productSectorsToRemove.Add(sectorId);
        }

        return productSectorsToRemove;
    }

    private HashSet<Guid> FindWillBeAdds(UpdateProductSectorsCommandRequest request,
        ICollection<ProductSector> productSectors)
    {
        HashSet<Guid> productSectorsToAdd = new();
        foreach (var sectorId in request.SectorIdentities)
        {
            bool isExist = productSectors.Any(_productSector => _productSector.SectorId.Equals(sectorId));
            if (isExist)
                continue;

            productSectorsToAdd.Add(sectorId);
        }

        return productSectorsToAdd;
    }
}