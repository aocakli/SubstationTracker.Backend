using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.BusinessRules;

public class SubstationSectorBusinessRules : IBusinessRules
{
    private readonly ISubstationSectorReadRepository _substationSectorReadRepository;
    private readonly ISectorReadRepository _sectorReadRepository;
    private readonly LanguageService _languageService;

    public SubstationSectorBusinessRules(ISubstationSectorReadRepository substationSectorReadRepository,
        ISectorReadRepository sectorReadRepository, LanguageService languageService)
    {
        _substationSectorReadRepository = substationSectorReadRepository;
        _sectorReadRepository = sectorReadRepository;
        _languageService = languageService;
    }

    public async Task<bool> SubstationIsDontHaveAnySectorsAsync(Guid substationId, HashSet<Guid> sectorIdentities)
    {
        var sectors = await _sectorReadRepository.GetAllAsync(
            exp: _sector => sectorIdentities.Contains(_sector.Id),
            features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (sectors.Any() is false)
            throw new BusinessException(_languageService.Get(Messages.SectorsAreNotFound));

        var substationSectors = await _substationSectorReadRepository.GetAllAsync(_substationSector =>
            _substationSector.SubstationId.Equals(substationId));
        if (substationSectors.Any() is false)
            return true;

        foreach (var substationSector in substationSectors)
        {
            var sector = sectors.FirstOrDefault(_sector => _sector.Id.Equals(substationSector.SectorId));
            if (sector is null)
                continue;

            string message = string.Format(_languageService.Get(Messages.TheSubstationIsAlreadyHaveTheSector),
                sector.Name);

            throw new BusinessException(message: message);
        }

        return true;
    }
}