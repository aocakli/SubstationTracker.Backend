using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Commands.
    CreateSubstationMovement;

public class CreateSubstationMovementCommandRequestHandler : IRequestHandler<CreateSubstationMovementCommandRequest,
    IDataResponse<CreateSubstationMovementCommandResponse>>
{
    private readonly ISubstationMovementWriteRepository _writeRepository;
    private readonly LanguageService _languageService;

    public CreateSubstationMovementCommandRequestHandler(ISubstationMovementWriteRepository writeRepository,
        LanguageService languageService)
    {
        _writeRepository = writeRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<CreateSubstationMovementCommandResponse>> Handle(
        CreateSubstationMovementCommandRequest request, CancellationToken cancellationToken)
    {
        SubstationMovement substationMovementToAdd =
            SubstationMovement.Create(substationId: request.SubstationId, processTime: request.ProcessTime);

        await _writeRepository.CreateAsync(substationMovementToAdd);

        if (request.IsSaveChanges && await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SubstationMovementIsNotCreated));

        return new SuccessDataResponse<CreateSubstationMovementCommandResponse>(
            message: _languageService.Get(Messages.SubstationMovementIsCreated),
            data: new CreateSubstationMovementCommandResponse(substationMovementToAdd.Id),
            statusCode: HttpStatusCode.Created);
    }
}