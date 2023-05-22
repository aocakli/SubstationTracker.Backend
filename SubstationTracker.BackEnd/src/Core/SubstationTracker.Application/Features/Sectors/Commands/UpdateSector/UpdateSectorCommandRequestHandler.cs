using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Sectors.BusinessRules;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Sectors.Commands.UpdateSector;

public class UpdateSectorCommandRequestHandler : IRequestHandler<UpdateSectorCommandRequest, IResponse>
{
    private readonly ISectorReadRepository _readRepository;
    private readonly ISectorWriteRepository _writeRepository;
    private readonly SectorBusinessRules _businessRules;
    private readonly LanguageService _languageService;

    public UpdateSectorCommandRequestHandler(ISectorReadRepository readRepository,
        ISectorWriteRepository writeRepository, SectorBusinessRules businessRules, LanguageService languageService)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _businessRules = businessRules;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(UpdateSectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.SectorNameIsShouldNotExistingFromDatabaseWithoutItSelfAsync(id: request.Id,
            name: request.Name);

        var documentToUpdate = await _readRepository.GetAsync(_sector => _sector.Id.Equals(request.Id));
        if (documentToUpdate is null)
            return new ErrorResponse(message: _languageService.Get(Messages.SectorIsNotFound),
                statusCode: HttpStatusCode.NotFound);

        documentToUpdate.Update(name: request.Name, description: request.Description);

        await _writeRepository.UpdateAsync(documentToUpdate);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(message: _languageService.Get(Messages.SectorIsNotUpdated));

        return new SuccessResponse(message: _languageService.Get(Messages.SectorIsUpdated),
            statusCode: HttpStatusCode.OK);
    }
}