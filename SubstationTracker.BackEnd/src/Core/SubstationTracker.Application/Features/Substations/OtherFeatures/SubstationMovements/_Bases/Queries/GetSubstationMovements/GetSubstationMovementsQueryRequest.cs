using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Queries.
    GetSubstationMovements;

public class GetSubstationMovementsQueryRequest : IPaginationRequest,
    IRequest<IPaginateDataResponse<ICollection<GetSubstationMovementsQueryResponse>>>
{
    public Guid? SubstationId { get; set; }
    public PaginationRequestBase Pagination { get; set; } = null!;
}