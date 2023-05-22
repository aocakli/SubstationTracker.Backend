using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.UpdateProductSectors;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Products._Bases.Commands.UpdateProduct;

public class UpdateProductCommandRequestHandler : IRequestHandler<UpdateProductCommandRequest, IResponse>
{
    private readonly IProductReadRepository _readRepository;
    private readonly IProductWriteRepository _writeRepository;
    private readonly LanguageService _languageService;
    private readonly FileService _fileService;
    private readonly IMediator _mediator;

    public UpdateProductCommandRequestHandler(IProductReadRepository readRepository,
        IProductWriteRepository writeRepository, LanguageService languageService, FileService fileService,
        IMediator mediator)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
        _fileService = fileService;
        _mediator = mediator;
    }

    public async Task<IResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _readRepository.GetByIdAsync(id: request.Id,
            features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (product is null)
            return new ErrorResponse(_languageService.Get(Messages.ProductIsNotFound));

        string oldPhotoPath = product.PhotoPath;

        string photoPath = product.PhotoPath;

        if (request.Image is not null)
            photoPath = await _fileService.SaveAsImage(file: request.Image, fileName: $"{Guid.NewGuid()}.png");

        product.Update(name: request.Name, unit: request.Unit, photoPath: photoPath);

        var updateProductSectorResult = await _mediator.Send(new UpdateProductSectorsCommandRequest(
            productId: product.Id,
            sectorIdentities: request.SectorIdentities,
            isSaveChanges: false));
        if (updateProductSectorResult.IsSuccess is false)
            return new ErrorResponse(response: updateProductSectorResult);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ProductIsNotUpdated));

        if (request.Image is not null)
            _fileService.FindAndIfExistThenDeleteFile(path: oldPhotoPath);

        return new SuccessResponse(
            message: _languageService.Get(Messages.ProductIsUpdated),
            statusCode: HttpStatusCode.OK);
    }
}