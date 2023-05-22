namespace SubstationTracker.Application.Utilities.Paginations;

public class PaginationRequestBase
{
    public PaginationRequestBase()
    {
    }

    public PaginationRequestBase(int page, int? itemCount, OrderBy orderBy)
    {
        Page = page;
        ItemCount = itemCount;
        OrderBy = orderBy;
    }

    public int Page { get; set; }
    public int? ItemCount { get; set; }
    public OrderBy OrderBy { get; set; }

    public static PaginationRequestBase Default()
    {
        return new PaginationRequestBase(page: 1, itemCount: null, orderBy: OrderBy.Ascending);
    }
}