using SubstationTracker.Application.Abstracts;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.Queries.GetResponsibleUserCountBySubstationId;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Application.Features.Substations._Bases.BusinessRules;

public class SubstationBusinessRules : IBusinessRules
{
    private readonly ISubstationReadRepository _readRepository;
    private readonly LanguageService _languageService;
    private readonly IMediator _mediator;

    public SubstationBusinessRules(ISubstationReadRepository readRepository, LanguageService languageService,
        IMediator mediator)
    {
        _readRepository = readRepository;
        _languageService = languageService;
        _mediator = mediator;
    }

    public async Task<bool> SubstationNameIsShouldNotExistFromDatabaseAsync(string substationName)
    {
        var isExist =
            await _readRepository.AnyAsync(_substation => _substation.Name.ToLower().Equals(substationName.ToLower()));
        if (isExist is false)
            return true;

        throw new BusinessException(_languageService.Get(Messages.SubstationNameIsAlreadyExist));
    }

    public async Task<bool> SubstationNameIsShouldNotExistFromDatabaseWithoutItSelfAsync(Guid id,
        string substationName)
    {
        var isExist = await _readRepository.AnyAsync(_substation =>
            _substation.Id.Equals(id) == false && _substation.Name.ToLower().Equals(substationName.ToLower()));
        if (isExist is false)
            return true;

        throw new BusinessException(_languageService.Get(Messages.SubstationNameIsAlreadyExist));
    }
}