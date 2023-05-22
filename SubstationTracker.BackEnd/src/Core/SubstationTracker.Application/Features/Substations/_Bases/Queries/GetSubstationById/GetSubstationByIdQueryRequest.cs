namespace SubstationTracker.Application.Features.Substations._Bases.Queries.GetSubstationById;

public class GetSubstationByIdQueryRequest : IRequest<IDataResponse<GetSubstationByIdQueryResponse>>
{
    public Guid Id { get; set; }
}