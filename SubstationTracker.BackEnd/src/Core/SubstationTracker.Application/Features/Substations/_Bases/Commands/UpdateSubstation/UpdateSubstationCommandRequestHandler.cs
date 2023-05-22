using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Substations._Bases.BusinessRules;
using SubstationTracker.Application.Helpers;
using SubstationTracker.Application.Repositories._Bases;
using SubstationTracker.Application.Repositories.Substations._Bases;
using SubstationTracker.Application.Utilities.Exceptions;

namespace SubstationTracker.Application.Features.Substations._Bases.Commands.UpdateSubstation;

public class UpdateSubstationCommandRequestHandler : IRequestHandler<UpdateSubstationCommandRequest, IResponse>
{
    private readonly ISubstationReadRepository _readRepository;
    private readonly ISubstationWriteRepository _writeRepository;
    private readonly LanguageService _languageService;
    private readonly FileService _fileService;
    private readonly SubstationBusinessRules _businessRules;

    public UpdateSubstationCommandRequestHandler(ISubstationReadRepository readRepository,
        ISubstationWriteRepository writeRepository, LanguageService languageService, FileService fileService,
        SubstationBusinessRules businessRules)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _languageService = languageService;
        _fileService = fileService;
        _businessRules = businessRules;
    }

    public async Task<IResponse> Handle(UpdateSubstationCommandRequest request, CancellationToken cancellationToken)
    {
        await _businessRules.SubstationNameIsShouldNotExistFromDatabaseWithoutItSelfAsync(id: request.Id,
            substationName: request.Name);

        var substationToUpdate = await _readRepository.GetAsync(
            exp: _substation => _substation.Id.Equals(request.Id),
            features: new RepoFeatures(includeAudit: true, noTracking: false));
        if (substationToUpdate is null)
            return new ErrorResponse(_languageService.Get(Messages.SubstationIsNotFound));

        string savedFilePath = substationToUpdate.PhotoPath;

        if (request.Image is not null)
        {
            string fileName = $"{Guid.NewGuid()}.png";

            savedFilePath = await _fileService.SaveAsImage(file: request.Image, fileName: fileName);
        }

        substationToUpdate.Update(
            name: request.Name,
            phoneNumber: request.PhoneNumber,
            address: request.Address,
            description: request.Description,
            photoPath: savedFilePath);

        await _writeRepository.UpdateAsync(substationToUpdate);

        if (await _writeRepository.SaveChangesAsync() is false)
            throw new ErrorException(_languageService.Get(Messages.SubstationIsNotUpdated));

        return new SuccessResponse(_languageService.Get(Messages.SubstationIsUpdated));
    }
}