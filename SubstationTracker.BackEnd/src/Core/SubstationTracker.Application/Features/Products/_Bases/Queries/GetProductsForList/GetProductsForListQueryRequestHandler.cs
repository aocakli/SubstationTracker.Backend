using SubstationTracker.Application.Repositories.Products._Bases;

namespace SubstationTracker.Application.Features.Products._Bases.Queries.GetProductsForList;

public class GetProductsForListQueryRequestHandler : IRequestHandler<GetProductsForListQueryRequest,
    IPaginateDataResponse<ICollection<GetProductsForListQueryResponse>>>
{
    private readonly IProductReadRepository _readRepository;

    public GetProductsForListQueryRequestHandler(IProductReadRepository readRepository)
    {
        _readRepository = readRepository;
    }

    public async Task<IPaginateDataResponse<ICollection<GetProductsForListQueryResponse>>> Handle(
        GetProductsForListQueryRequest request, CancellationToken cancellationToken)
    {
        return await _readRepository.GetProductsForListAsync(pagination: request.Pagination);
    }
}