using SubstationTracker.Application.Constants;
using SubstationTracker.Application.Repositories.Substations.OtherRepositories.SubstationMovements._Bases;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.Paginations;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements;
using SubstationTracker.Domain.Concrete.Substations.OtherDomains.SubstationMovements.OtherDomains.Inventories;

namespace SubstationTracker.Application.Features.Substations.OtherFeatures.SubstationMovements._Bases.Queries.
    GetSubstationMovements;

public class
    GetSubstationMovementsQueryRequestHandler : IRequestHandler<
        GetSubstationMovementsQueryRequest,
        IPaginateDataResponse<ICollection<GetSubstationMovementsQueryResponse>>>
{
    private readonly ISubstationMovementReadRepository _readRepository;
    private readonly LanguageService _languageService;

    public GetSubstationMovementsQueryRequestHandler(ISubstationMovementReadRepository readRepository,
        LanguageService languageService)
    {
        _readRepository = readRepository;
        _languageService = languageService;
    }

    public async Task<IPaginateDataResponse<ICollection<GetSubstationMovementsQueryResponse>>> Handle(
        GetSubstationMovementsQueryRequest request,
        CancellationToken cancellationToken)
    {
        List<GetSubstationMovementsQueryResponse> datas = new();

        var substationMovements = await _readRepository.GetWithIncludesAsync();
        if (substationMovements.Any() is false)
            return new SuccessPaginateDataResponse<ICollection<GetSubstationMovementsQueryResponse>>(
                message: string.Empty,
                data: datas,
                pagination: PaginationDto.Empty());

        decimal availablePrice = decimal.Zero;

        Dictionary<Guid, decimal> availableStocks = new();

        foreach (var substationMovement in substationMovements)
        {
            GetSubstationMovementsQueryResponse? response = null;

            ProcessInventoryMovement(substationMovement: substationMovement, response: ref response,
                availablePrice: ref availablePrice, availableStocks: availableStocks);

            if (response is null)
                continue;

            datas.Add(response);
        }

        datas = request.Pagination.OrderBy is OrderBy.Ascending
            ? datas.OrderBy(_substation => _substation.ProcessTime).ToList()
            : datas.OrderByDescending(_substation => _substation.ProcessTime).ToList();

        datas = datas.Skip((request.Pagination.Page - 1) * request.Pagination.ItemCount ?? 0).ToList();

        if (request.Pagination.ItemCount.HasValue)
            datas = datas.Take(request.Pagination.ItemCount.Value).ToList();

        return new SuccessPaginateDataResponse<ICollection<GetSubstationMovementsQueryResponse>>(
            message: string.Empty,
            data: datas,
            pagination: new PaginationDto(totalCount: substationMovements.Count,
                page: request.Pagination.Page,
                itemCount: datas.Count));
    }

    public void ProcessInventoryMovement(SubstationMovement substationMovement,
        ref GetSubstationMovementsQueryResponse? response, ref decimal availablePrice,
        Dictionary<Guid, decimal> availableStocks)
    {
        if (substationMovement.Inventory is null)
            return;

        Guid productId = substationMovement.Inventory.ProductId;
        
        if (availableStocks.TryGetValue(key: productId, out decimal availableQuantity) is false)
            availableStocks.Add(key: productId, value: 0);

        var inventory = substationMovement.Inventory;

        string movementType = "";

        if (inventory.InventoryEntry is not null)
        {
            availablePrice -= inventory.TotalPrice;
            availableQuantity += inventory.Quantity;
            movementType = "Stok Girişi";
        }
        else if (inventory.InventoryOut is not null)
        {
            availablePrice += inventory.TotalPrice;
            availableQuantity -= inventory.Quantity;
            movementType = "Stok Çıkışı";
        }
        else
            throw new ErrorException("Inventory type is unknown. Please contact development team.");

        availableStocks[productId] = availableQuantity;

        response = GetSubstationMovementsQueryResponse.CreateStockEntry(
            substationMovement: substationMovement,
            movementType: movementType,
            availablePrice: availablePrice,
            availableQuantity: availableQuantity);
    }
}