using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Features.Sectors.Queries.GetSectorsByIdentities;
using SubstationTracker.Application.Features.Users._Bases.Dtos;
using SubstationTracker.Application.Features.Users._Bases.Queries.GetUsersByIdentities;
using SubstationTracker.Application.Repositories.Substations._Bases;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;

public class GetSubstationByIdQueryRequestHandler : IRequestHandler<GetSubstationByIdQueryRequest,
    IDataResponse<GetSubstationByIdQueryResponse>>
{
    private readonly ISubstationReadRepository _readRepository;
    private readonly IMediator _mediator;
    private readonly LanguageService _languageService;

    public GetSubstationByIdQueryRequestHandler(ISubstationReadRepository readRepository, IMediator mediator,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _mediator = mediator;
        _languageService = languageService;
    }

    public async Task<IDataResponse<GetSubstationByIdQueryResponse>> Handle(GetSubstationByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var substation = await _readRepository.GetByIdAsync(id: request.Id);
        if (substation is null)
            return new ErrorDataResponse<GetSubstationByIdQueryResponse>(
                message: _languageService.Get(Messages.SubstationIsNotFound));

        HashSet<Guid> userIdentities = substation.SubstationResponsibleUsers
            .Select(_substationResponsibleUser => _substationResponsibleUser.ResponsibleUserId)
            .ToHashSet();

        IDataResponse<ICollection<UserDto>>? usersResult = null;
        if (userIdentities.Any())
        {
            usersResult =
                await _mediator.Send(new GetUsersByIdentitiesQueryRequest(identities: userIdentities));
            if (usersResult.IsSuccess is false)
                return new ErrorDataResponse<GetSubstationByIdQueryResponse>(usersResult.Message);
        }

        HashSet<Guid> sectorIdentities = substation.SubstationSectors
            .Select(_substationSector => _substationSector.SectorId)
            .ToHashSet();

        var sectorsResult =
            await _mediator.Send(new GetSectorsByIdentitiesQueryRequest(identities: sectorIdentities));
        if (sectorsResult.IsSuccess is false)
            return new ErrorDataResponse<GetSubstationByIdQueryResponse>(sectorsResult.Message);

        GetSubstationByIdQueryResponse response = GetSubstationByIdQueryResponse.Create(id: substation.Id,
            sectors: sectorsResult.Data,
            responsibleUsers: usersResult?.Data,
            name: substation.Name,
            phoneNumber: substation.PhoneNumber,
            address: substation.Address,
            description: substation.Description,
            photoPath: substation.PhotoPath);

        return new SuccessDataResponse<GetSubstationByIdQueryResponse>(
            message: _languageService.Get(Messages.SubstationIsBrought),
            data: response);
    }
}