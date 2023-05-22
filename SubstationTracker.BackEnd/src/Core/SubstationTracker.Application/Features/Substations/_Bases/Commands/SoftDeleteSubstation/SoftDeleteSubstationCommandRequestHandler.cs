using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.SoftDeleteSubstation;

public class SoftDeleteSubstationCommandRequestHandler : IRequestHandler<SoftDeleteSubstationCommandRequest, IResponse>
{
    private readonly ISubstationReadRepository _readRepository;
    private readonly ISubstationWriteRepository _writeRepository;
    private readonly LanguageService _languageService;

    public SoftDeleteSubstationCommandRequestHandler(ISubstationReadRepository readRepository,
        ISubstationWriteRepository writeRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(SoftDeleteSubstationCommandRequest request, CancellationToken cancellationToken)
    {
        var substation = await _readRepository.GetAsync(exp: _substation => _substation.Id.Equals(request.Id),
            features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (substation is null)
            return new ErrorResponse(_languageService.Get(Messages.SubstationIsNotFound));

        await _writeRepository.SoftDeleteAsync(substation);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SubstationIsNotDeleted));

        return new SuccessResponse(_languageService.Get(Messages.SubstationIsDeleted));
    }
}