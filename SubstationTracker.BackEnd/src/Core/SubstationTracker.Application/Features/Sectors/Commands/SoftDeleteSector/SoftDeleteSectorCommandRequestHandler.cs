using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Sectors.Commands.SoftDeleteSector;

public class SoftDeleteSectorCommandRequestHandler : IRequestHandler<SoftDeleteSectorCommandRequest, IResponse>
{
    private readonly ISectorReadRepository _sectorReadRepository;
    private readonly ISectorWriteRepository _sectorWriteRepository;
    private readonly LanguageService _languageService;

    public SoftDeleteSectorCommandRequestHandler(ISectorReadRepository sectorReadRepository,
        ISectorWriteRepository sectorWriteRepository, LanguageService languageService)
    {
        _sectorReadRepository = sectorReadRepository;
        _sectorWriteRepository = sectorWriteRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(SoftDeleteSectorCommandRequest request, CancellationToken cancellationToken)
    {
        var documentToSoftDelete =
            await _sectorReadRepository.GetAsync(
                exp: _sector => _sector.Id.Equals(request.Id),
                features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (documentToSoftDelete is null)
            return new ErrorResponse(message: _languageService.Get(Messages.SectorIsNotFound),
                statusCode: HttpStatusCode.NotFound);

        await _sectorWriteRepository.SoftDeleteAsync(documentToSoftDelete);

        if (await _sectorWriteRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SectorIsNotDeleted));

        return new SuccessResponse(message: _languageService.Get(Messages.SectorIsDeleted));
    }
}