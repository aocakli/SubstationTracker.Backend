using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsBySubstation;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Commands.
    CreateSubstationMovement;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.
    Inventories;
using SubstationTracker.Application.Services;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories
    ._Bases.Commands.CreateInventory;

public class CreateInventoryCommandRequestHandler : IRequestHandler<CreateInventoryCommandRequest,
    IDataResponse<CreateInventoryCommandResponse>>
{
    private readonly IInventoryWriteRepository _writeRepository;
    private readonly LanguageService _languageService;
    private readonly IMediator _mediator;
    private readonly RequestService _requestService;

    public CreateInventoryCommandRequestHandler(IInventoryWriteRepository writeRepository,
        LanguageService languageService, IMediator mediator, RequestService requestService)
    {
        _writeRepository = writeRepository;
        _languageService = languageService;
        _mediator = mediator;
        _requestService = requestService;
    }

    public async Task<IDataResponse<CreateInventoryCommandResponse>> Handle(CreateInventoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var productsOfSubstationResult = await _mediator.Send(new GetProductsBySubstationQueryRequest(
            userId: _requestService.PerpetratorUserId!.Value,
            substationId: request.SubstationId, pagination: PaginationRequestBase.Default()));
        if (productsOfSubstationResult.IsSuccess is false)
            return new ErrorDataResponse<CreateInventoryCommandResponse>(productsOfSubstationResult);

        var product = productsOfSubstationResult.Data
            .FirstOrDefault(_product => _product.Id.Equals(request.ProductId));

        if (product is null)
            throw new BusinessException(_languageService.Get(Messages.ThisProductIsNotAvailableAtThisSubstation));

        var createSubstationMovementResult = await _mediator.Send(new CreateSubstationMovementCommandRequest(
            substationId: request.SubstationId,
            processTime: request.ProcessTime,
            isSaveChanges: false));
        if (createSubstationMovementResult.IsSuccess is false)
            return new ErrorDataResponse<CreateInventoryCommandResponse>(createSubstationMovementResult);

        var inventoryToAdd = Inventory.Create(
            substationMovementId: createSubstationMovementResult.Data.Id,
            productId: product.Id,
            productName: product.Name,
            quantity: request.Quantity,
            totalPrice: request.TotalPrice,
            unit: product.Unit,
            description: request.Description);

        await _writeRepository.CreateAsync(inventoryToAdd);


        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.InventoryDataIsNotCreated));

        return new SuccessDataResponse<CreateInventoryCommandResponse>(
            message: _languageService.Get(Messages.InventoryDataIsCreated),
            data: new CreateInventoryCommandResponse(id: inventoryToAdd.Id),
            statusCode: HttpStatusCode.Created);
    }
}