using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements.OtherRepositories.Inventories.InventoryEntries;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements.OtherFeatures.Inventories.OtherFeatures.InventoryEntries.Commands.
    CreateInventoryEntry;

public class CreateInventoryEntryCommandRequestHandler : IRequestHandler<CreateInventoryEntryCommandRequest, IResponse>
{
    private readonly IInventoryEntryWriteRepository _writeRepository;
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;

    public CreateInventoryEntryCommandRequestHandler(IInventoryEntryWriteRepository writeRepository,
        LanguageService languageService, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _languageService = languageService;
        _mediator = mediator;
    }

    public async Task<IResponse> Handle(CreateInventoryEntryCommandRequest request, CancellationToken cancellationToken)
    {
        var createInventoryResult = await _mediator.Send(request.Inventory);
        if (createInventoryResult.IsSuccess is false)
            return new ErrorResponse(createInventoryResult);

        InventoryEntry inventoryEntryToAdd = InventoryEntry.Create(inventoryId: createInventoryResult.Data.Id);

        await _writeRepository.CreateAsync(inventoryEntryToAdd);
        
        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.InventoryDataIsNotCreated));

        return new SuccessResponse(
            message: _languageService.Get(Messages.InventoryDataIsCreated),
            statusCode: HttpStatusCode.Created);
    }
}