using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.BusinessRules;
using SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationSectors.Commands.
    CreateSectorsToSubstation;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Domain.Concrete.Substations._Bases;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.CreateSubstation;

public class CreateSubstationCommandRequestHandler : IRequestHandler<CreateSubstationCommandRequest,
    IDataResponse<CreateSubstationCommandResponse>>
{
    private readonly ISubstationWriteRepository _writeRepository;
    private readonly SubstationBusinessRules _substationBusinessRules;
    private readonly LanguageService _languageService;
    private readonly FileService _fileService;
    private readonly IMediator _mediator;

    public CreateSubstationCommandRequestHandler(ISubstationWriteRepository writeRepository,
        SubstationBusinessRules substationBusinessRules,
        LanguageService languageService, FileService fileService, IMediator mediator)
    {
        _writeRepository = writeRepository;
        _substationBusinessRules = substationBusinessRules;
        _languageService = languageService;
        _fileService = fileService;
        _mediator = mediator;
    }

    public async Task<IDataResponse<CreateSubstationCommandResponse>> Handle(CreateSubstationCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _substationBusinessRules.SubstationNameIsShouldNotExistFromDatabaseAsync(substationName: request.Name);

        string savedFilePath = string.Empty;

        if (request.Image is not null)
        {
            string fileName = $"{Guid.NewGuid()}.png";

            savedFilePath = await _fileService.SaveAsImage(file: request.Image, fileName: fileName);
        }

        Substation substationToAdd = Substation.Create(
            name: request.Name,
            phoneNumber: request.PhoneNumber,
            address: request.Address,
            description: request.Description,
            photoPath: savedFilePath);

        await _writeRepository.CreateAsync(substationToAdd);

        var createSectorsToSubstationResult = await _mediator.Send(new CreateSectorsToSubstationCommandRequest(
            substationId: substationToAdd.Id,
            sectorIdentities: request.SectorIdentities,
            isSaveChanges: false));
        if (createSectorsToSubstationResult.IsSuccess is false)
            return new ErrorDataResponse<CreateSubstationCommandResponse>(createSectorsToSubstationResult.Message);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SubstationIsNotCreated));

        CreateSubstationCommandResponse response = new(substationToAdd.Id);

        return new SuccessDataResponse<CreateSubstationCommandResponse>(
            message: _languageService.Get(Messages.SubstationIsCreated),
            statusCode: HttpStatusCode.Created,
            data: response);
    }
}