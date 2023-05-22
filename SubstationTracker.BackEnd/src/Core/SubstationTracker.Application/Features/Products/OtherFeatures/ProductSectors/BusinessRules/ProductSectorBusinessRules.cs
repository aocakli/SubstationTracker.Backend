using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Products.ProductSectors;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.BusinessRules;

public class ProductSectorBusinessRules : IBusinessRules
{
    private readonly IProductSectorReadRepository _productSectorReadRepository;
    private readonly LanguageService _languageService;
    public ProductSectorBusinessRules(IProductSectorReadRepository productSectorReadRepository, LanguageService languageService)
    {
        _productSectorReadRepository = productSectorReadRepository;
        _languageService = languageService;
    }

    public async Task<bool> ProductSectorsAreShouldAlreadyNotExistInProductAsync(Guid productId,
        HashSet<Guid> sectorIdentities)
    {
        bool isExist = await _productSectorReadRepository.AnyAsync(_productSector =>
            _productSector.ProductId.Equals(productId) && sectorIdentities.Contains(_productSector.SectorId));
        if (isExist)
            throw new BusinessException(_languageService.Get(Messages.TheProductAndSectorAlreadyRelated));

        return true;
    }
}