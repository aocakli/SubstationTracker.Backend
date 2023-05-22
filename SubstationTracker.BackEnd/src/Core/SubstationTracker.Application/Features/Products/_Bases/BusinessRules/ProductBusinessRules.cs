using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Products._Bases.BusinessRules;

public class ProductBusinessRules : IBusinessRules
{
    private readonly IProductReadRepository _productReadRepository;
    private readonly LanguageService _languageService;
    public ProductBusinessRules(IProductReadRepository productReadRepository, LanguageService languageService)
    {
        _productReadRepository = productReadRepository;
        _languageService = languageService;
    }

    public async Task<bool> ProductNameIsShouldNotExistFromDatabaseAsync(string name)
    {
        var isExist = await _productReadRepository.AnyAsync(exp: _product => _product.Name.ToLower().Equals(name.ToLower()));
        if (isExist)
            throw new BusinessException(message: _languageService.Get(Messages.ProductNameIsAlreadyExist));

        return true;
    }
}