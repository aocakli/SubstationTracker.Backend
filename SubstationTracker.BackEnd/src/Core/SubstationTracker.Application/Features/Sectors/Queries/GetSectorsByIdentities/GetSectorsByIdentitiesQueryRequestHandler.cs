using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;

public class GetSectorsByIdentitiesQueryRequestHandler : IRequestHandler<GetSectorsByIdentitiesQueryRequest,
    IDataResponse<ICollection<GetSectorsByIdentitiesQueryResponse>>>
{
    private readonly ISectorReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetSectorsByIdentitiesQueryRequestHandler(ISectorReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<ICollection<GetSectorsByIdentitiesQueryResponse>>> Handle(
        GetSectorsByIdentitiesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var sectors = await _readRepository.GetAllAsync(exp: _sector => request.Identities.Contains(_sector.Id));

        List<GetSectorsByIdentitiesQueryResponse> response = sectors
            .Select(_sector =>
            {
                return GetSectorsByIdentitiesQueryResponse.Create(id: _sector.Id, name: _sector.Name, description: _sector.Description);
            }).ToList();

        return new SuccessDataResponse<ICollection<GetSectorsByIdentitiesQueryResponse>>(
            message: _languageService.Get(Messages.SectorsAreListed),
            data: response);
    }
}