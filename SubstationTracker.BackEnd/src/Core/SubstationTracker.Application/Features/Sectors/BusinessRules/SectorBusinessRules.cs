using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Sectors.BusinessRules;

public class SectorBusinessRules : IBusinessRules
{
    private readonly ISectorReadRepository _sectorReadRepository;
    private readonly LanguageService _languageService;

    public SectorBusinessRules(ISectorReadRepository sectorReadRepository, LanguageService languageService)
    {
        _sectorReadRepository = sectorReadRepository;
        _languageService = languageService;
    }

    public async Task<bool> SectorNamesAreShouldNotExistingFromDatabaseAsync(HashSet<string> sectorNames)
    {
        var loweredSectorNames = sectorNames.Select(_sectorName => _sectorName.ToLower()).ToHashSet();

        var sectors =
            await _sectorReadRepository.GetAllAsync(_sector => loweredSectorNames.Contains(_sector.Name.ToLower()));
        if (sectors.Any() is false)
            return true;

        var loweredExistingSectorNames = sectors.Select(_sector => _sector.Name.ToLower()).ToHashSet();

        var existingSectorNames =
            loweredSectorNames.Where(_sectorName => loweredExistingSectorNames.Contains(_sectorName)).ToList();
        if (existingSectorNames.Any() is false)
            return true;

        string sectorNamesForError = string.Join(", ", existingSectorNames);

        throw new BusinessException(
            message: string.Format(_languageService.Get(Messages.TheSectorNamesAreAlreadyExist), sectorNamesForError));
    }

    public async Task<bool> SectorNameIsShouldNotExistingFromDatabaseWithoutItSelfAsync(Guid id, string name)
    {
        var sector = await _sectorReadRepository.GetAsync(_sector =>
            _sector.Id.Equals(id) == false && name.ToLower().Equals(_sector.Name.ToLower()));
        if (sector is null)
            return true;

        throw new BusinessException(message:
            string.Format(_languageService.Get(Messages.SectorNameIsAlreadyExist), name));
    }
}