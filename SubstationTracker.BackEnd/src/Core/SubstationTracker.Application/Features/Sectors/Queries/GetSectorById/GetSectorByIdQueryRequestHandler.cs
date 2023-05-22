using FluentValidation.Resources;
using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Sectors;
using SubstationTracker.Application.Repositories.Sectors._Bases;

namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;

public class GetSectorByIdQueryRequestHandler : IRequestHandler<GetSectorByIdQueryRequest, IDataResponse<GetSectorByIdQueryResponse>>
{
    private readonly ISectorReadRepository _readRepository;
    private readonly LanguageService _languageService;
    public GetSectorByIdQueryRequestHandler(ISectorReadRepository readRepository, LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IDataResponse<GetSectorByIdQueryResponse>> Handle(GetSectorByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var sector = await _readRepository.GetAsync(_sector => _sector.Id.Equals(request.Id));
        if (sector is null)
            return new ErrorDataResponse<GetSectorByIdQueryResponse>(message: _languageService.Get(Messages.SectorIsNotFound));

        var sectorDto = GetSectorByIdQueryResponse.Create(id: sector.Id, name: sector.Name, description: sector.Description);
        
        return new SuccessDataResponse<GetSectorByIdQueryResponse>(
            message: _languageService.Get(Messages.SectorIsBrought),
            data: sectorDto);
    }
}