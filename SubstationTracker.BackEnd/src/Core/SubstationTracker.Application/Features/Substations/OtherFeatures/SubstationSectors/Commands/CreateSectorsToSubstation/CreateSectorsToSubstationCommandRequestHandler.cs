using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.BusinessRules;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationSectors;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationSectors;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.Commands.
    CreateSectorsToSubstation;

public class
    CreateSectorsToSubstationCommandRequestHandler : IRequestHandler<CreateSectorsToSubstationCommandRequest, IResponse>
{
    private readonly ISubstationSectorWriteRepository _substationSectorWriteRepository;
    private readonly SubstationSectorBusinessRules _businessRules;
    private readonly LanguageService _languageService;

    public CreateSectorsToSubstationCommandRequestHandler(SubstationSectorBusinessRules businessRules,
        ISubstationSectorWriteRepository substationSectorWriteRepository, LanguageService languageService)
    {
        _businessRules = businessRules;
        _substationSectorWriteRepository = substationSectorWriteRepository;
        _languageService = languageService;
    }

    public async Task<IResponse> Handle(CreateSectorsToSubstationCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _businessRules.SubstationIsDontHaveAnySectorsAsync(substationId: request.SubstationId,
            sectorIdentities: request.SectorIdentities);

        List<SubstationSector> substationSectorsToAdd = request.SectorIdentities
            .Select(_sectorId => SubstationSector.Create(substationId: request.SubstationId, sectorId: _sectorId))
            .ToList();

        await _substationSectorWriteRepository.CreateBulkAsync(substationSectorsToAdd);

        if (request.IsSaveChanges && await _substationSectorWriteRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SectorIsNotAddedToSubstation));

        return new SuccessResponse(_languageService.Get(Messages.SectorIsAddedToSubstation));
    }
}