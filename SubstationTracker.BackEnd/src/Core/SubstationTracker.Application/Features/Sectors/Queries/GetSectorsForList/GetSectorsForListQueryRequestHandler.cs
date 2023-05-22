using System.Net;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorsForList;

public class
    GetSectorsForListQueryRequestHandler : IRequestHandler<GetSectorsForListQueryRequest,
        IPaginateDataResponse<ICollection<GetSectorsForListQueryResponse>>>
{
    private readonly ISectorReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetSectorsForListQueryRequestHandler(ISectorReadRepository readRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IPaginateDataResponse<ICollection<GetSectorsForListQueryResponse>>> Handle(
        GetSectorsForListQueryRequest request,
        CancellationToken cancellationToken)
    {
        var sectors = await _readRepository.GetAllPaginateAsync(exp: null, pagination: request.Pagination);
        if (sectors.Data.Any() is false)
            return new ErrorPaginateDataResponse<ICollection<GetSectorsForListQueryResponse>>(
                message: _languageService.Get(Messages.SectorsAreNotFound),
                data: new List<GetSectorsForListQueryResponse>(),
                pagination: sectors.Pagination);

        List<GetSectorsForListQueryResponse> responses = sectors.Data
            .Select(_sector =>
                GetSectorsForListQueryResponse.Create(id: _sector.Id, name: _sector.Name,
                    description: _sector.Description))
            .ToList();

        return new SuccessPaginateDataResponse<ICollection<GetSectorsForListQueryResponse>>(
            message: string.Empty,
            data: responses,
            statusCode: HttpStatusCode.OK,
            pagination: sectors.Pagination);
    }
}