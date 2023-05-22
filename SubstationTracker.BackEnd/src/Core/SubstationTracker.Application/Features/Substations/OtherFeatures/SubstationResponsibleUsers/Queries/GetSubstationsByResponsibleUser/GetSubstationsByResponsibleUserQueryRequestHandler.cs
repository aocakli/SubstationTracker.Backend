using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationResponsibleUsers.Queries.
    GetSubstationsByResponsibleUser;

public class
    GetSubstationsByResponsibleUserQueryRequestHandler : IRequestHandler<GetSubstationsByResponsibleUserQueryRequest,
        IDataResponse<ICollection<GetSubstationsByResponsibleUserQueryResponse>>>
{
    private readonly ISubstationResponsibleUserReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetSubstationsByResponsibleUserQueryRequestHandler(ISubstationResponsibleUserReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<ICollection<GetSubstationsByResponsibleUserQueryResponse>>> Handle(
        GetSubstationsByResponsibleUserQueryRequest request,
        CancellationToken cancellationToken)
    {
        var substations = await _readRepository.GetSubstationsByResponsibleUserAsync(userId: request.UserId);
        if (substations.Any() is false)
            return new ErrorDataResponse<ICollection<GetSubstationsByResponsibleUserQueryResponse>>(
                _languageService.Get(Messages.SubstationsAreNotFound));

        return new SuccessDataResponse<ICollection<GetSubstationsByResponsibleUserQueryResponse>>(
            message: string.Empty,
            data: substations);
    }
}