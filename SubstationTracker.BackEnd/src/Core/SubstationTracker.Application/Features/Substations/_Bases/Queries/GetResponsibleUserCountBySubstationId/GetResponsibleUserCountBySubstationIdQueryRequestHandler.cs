using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationResponsibleUsers;

namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetResponsibleUserCountBySubstationId;

public class
    GetResponsibleUserCountBySubstationIdQueryRequestHandler : IRequestHandler<
        GetResponsibleUserCountBySubstationIdQueryRequest, IDataResponse<long>>
{
    private readonly ISubstationResponsibleUserReadRepository _readRepository;

    public GetResponsibleUserCountBySubstationIdQueryRequestHandler(
        ISubstationResponsibleUserReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<IDataResponse<long>> Handle(GetResponsibleUserCountBySubstationIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var responsibleUserCountOfTheSubstation =
            await _readRepository.CountAsync(_substation => _substation.Id.Equals(request.SubstationId));

        return new SuccessDataResponse<long>(message: string.Empty, data: responsibleUserCountOfTheSubstation);
    }
}