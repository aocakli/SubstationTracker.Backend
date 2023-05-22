using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryOuts;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryOuts.Commands.
    CreateInventoryOut;

public class CreateInventoryOutCommandRequestHandler : IRequestHandler<CreateInventoryOutCommandRequest, IResponse>
{
    private readonly IInventoryOutWriteRepository _writeRepository;
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;

    public CreateInventoryOutCommandRequestHandler(IInventoryOutWriteRepository writeRepository,
        LanguageService languageService, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _languageService = languageService;
        _mediator = mediator;
    }

    public async Task<IResponse> Handle(CreateInventoryOutCommandRequest request, CancellationToken cancellationToken)
    {
        var createInventoryResult = await _mediator.Send(request.Inventory);
        if (createInventoryResult.IsSuccess is false)
            return new ErrorResponse(createInventoryResult);

        InventoryOut inventoryOutToAdd = InventoryOut.Create(inventoryId: createInventoryResult.Data.Id);

        await _writeRepository.CreateAsync(inventoryOutToAdd);
        
        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.InventoryDataIsNotCreated));

        return new SuccessResponse(
            message: _languageService.Get(Messages.InventoryDataIsCreated),
            statusCode: HttpStatusCode.Created);
    }
}