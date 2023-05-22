using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Products._Bases.Commands.SoftDeleteProduct;

public class SoftDeleteProductCommandRequestHandler : IRequestHandler<SoftDeleteProductCommandRequest, IResponse>
{
    private readonly IProductReadRepository _readRepository;
    private readonly IProductWriteRepository _writeRepository;
    private readonly LanguageService _languageService;

    public SoftDeleteProductCommandRequestHandler(IProductReadRepository readRepository,
        IProductWriteRepository writeRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(SoftDeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetByIdAsync(id: request.Id,
            features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (product is null)
            return new ErrorResponse(_languageService.Get(Messages.ProductIsNotFound));

        await _writeRepository.SoftDeleteAsync(product);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ProductIsNotDeleted));

        return new SuccessResponse(
            message: _languageService.Get(Messages.ProductIsDeleted),
            statusCode: HttpStatusCode.OK);
    }
}