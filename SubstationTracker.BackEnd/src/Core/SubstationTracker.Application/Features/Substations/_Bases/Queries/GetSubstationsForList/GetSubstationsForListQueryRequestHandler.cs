using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations._Bases;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationsForList;

public class GetSubstationsForListQueryRequestHandler : IRequestHandler<GetSubstationsForListQueryRequest,
    IPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>>
{
    private readonly ISubstationReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetSubstationsForListQueryRequestHandler(ISubstationReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>> Handle(
        GetSubstationsForListQueryRequest request, CancellationToken cancellationToken)
    {
        var substations = await _readRepository.GetSubstationsForListAsync(pagination: request.Pagination);
        if (substations.Data.Any() is false)
            return new ErrorPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>(
                message: _languageService.Get(Messages.SubstationsAreNotFound),
                data: new List<GetSubstationsForListQueryResponse>(),
                pagination: substations.Pagination);

        return new SuccessPaginateDataResponse<ICollection<GetSubstationsForListQueryResponse>>(
            message: string.Empty,
            data: substations.Data,
            pagination: substations.Pagination);
    }
}