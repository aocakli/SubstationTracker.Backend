namespace SubstationTracker.Application.Features.Sectors.Queries.GetSectorById;

public class GetSectorByIdQueryRequest : IRequest<IDataResponse<GetSectorByIdQueryResponse>>
{
    public Guid Id { get; set; }
}