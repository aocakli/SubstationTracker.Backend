using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Products._Bases.BusinessRules;
using SubstationTracker.Application.Features.Products.OtherFeatures.ProductSectors.Commands.CreateSectorsToProduct;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories.Products._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Products;

namespace SubstationTracker.Application.Features.Products._Bases.Commands.CreateProduct;

public class
    CreateProductCommandRequestHandler : IRequestHandler<CreateProductCommandRequest,
        IDataResponse<CreateProductCommandResponse>>
{
    private readonly IProductWriteRepository _writeRepository;
    private readonly ProductBusinessRules _productBusinessRules;
    private readonly LanguageService _languageService;
    private readonly FileService _fileService;
    private readonly IMediator _mediator;
    public CreateProductCommandRequestHandler(IProductWriteRepository writeRepository,
        ProductBusinessRules productBusinessRules, LanguageService languageService, FileService fileService, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _productBusinessRules = productBusinessRules;
        _languageService = languageService;
        _fileService = fileService;
        _mediator = mediator;
    }

    public async Task<IDataResponse<CreateProductCommandResponse>> Handle(CreateProductCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _productBusinessRules.ProductNameIsShouldNotExistFromDatabaseAsync(name: request.Name);

        string savedFilePath = string.Empty;

        if (request.Image is not null)
        {
            string fileName = $"{Guid.NewGuid()}.png";

            savedFilePath = await _fileService.SaveAsImage(file: request.Image, fileName: fileName);
        }
        
        var productToCreate = Product.Create(name: request.Name, unit: request.Unit, photoPath: savedFilePath);

        await _writeRepository.CreateAsync(productToCreate);

        var createSectorsToProductResult = await _mediator.Send(new CreateSectorsToProductQueryRequest(productId: productToCreate.Id,
            sectorIdentities: request.SectorIdentities,
            isSaveChanges: false));
        if (createSectorsToProductResult.IsSuccess is false)
            return new ErrorDataResponse<CreateProductCommandResponse>(response: createSectorsToProductResult);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.ProductIsNotCreated));

        return new SuccessDataResponse<CreateProductCommandResponse>(
            message: _languageService.Get(Messages.ProductIsCreated),
            statusCode: HttpStatusCode.Created,
            data: new CreateProductCommandResponse(id: productToCreate.Id));
    }
}