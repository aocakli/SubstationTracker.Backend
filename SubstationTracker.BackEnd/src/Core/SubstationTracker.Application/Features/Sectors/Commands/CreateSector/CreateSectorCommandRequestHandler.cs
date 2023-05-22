using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Sectors.BusinessRules;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Sectors;

namespace SubstationTracker.Application.Features.Sectors.Commands.CreateSector;

public class CreateSectorCommandRequestHandler : IRequestHandler<CreateSectorCommandRequest, IResponse>
{
    private readonly ISectorWriteRepository _writeRepository;
    private readonly LanguageService _languageService;
    private readonly SectorBusinessRules _sectorBusinessRules;

    public CreateSectorCommandRequestHandler(ISectorWriteRepository writeRepository, LanguageService languageService,
        SectorBusinessRules sectorBusinessRules)
    {
        _writeRepository = writeRepository;
        _languageService = languageService;
        _sectorBusinessRules = sectorBusinessRules;
    }

    public async Task<IResponse> Handle(CreateSectorCommandRequest request, CancellationToken cancellationToken)
    {
        await _sectorBusinessRules.SectorNamesAreShouldNotExistingFromDatabaseAsync(sectorNames: new HashSet<string>()
        {
            request.Name
        });

        Sector sectorToAdd = Sector.Create(name: request.Name, description: request.Description);

        await _writeRepository.CreateAsync(sectorToAdd);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(message: _languageService.Get(Messages.SectorsAreNotCreated));

        return new SuccessResponse(
            message: _languageService.Get(Messages.SectorsAreCreated),
            statusCode: HttpStatusCode.Created);
    }
}