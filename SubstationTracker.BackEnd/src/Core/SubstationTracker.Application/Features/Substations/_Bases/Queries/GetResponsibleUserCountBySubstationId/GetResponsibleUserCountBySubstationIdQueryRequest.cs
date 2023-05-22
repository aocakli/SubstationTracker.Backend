namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetResponsibleUserCountBySubstationId;

public class GetResponsibleUserCountBySubstationIdQueryRequest : IRequest<IDataResponse<long>>
{
    public GetResponsibleUserCountBySubstationIdQueryRequest()
    {
    }

    public GetResponsibleUserCountBySubstationIdQueryRequest(Guid substationId)
    {
        SubstationId = substationId;
    }

    public Guid SubstationId { get; set; }
}