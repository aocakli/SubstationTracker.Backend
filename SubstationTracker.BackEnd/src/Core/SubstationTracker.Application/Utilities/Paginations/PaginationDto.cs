namespace SubstationTracker.Application.Utilities.Paginations;

public class PaginationDto
{
    public PaginationDto()
    {
    }

    public PaginationDto(long totalCount, long page, long itemCount)
    {
        TotalCount = totalCount;
        Page = page;
        ItemCount = itemCount;
    }

    public long TotalCount { get; set; }
    public long Page { get; set; }
    public long ItemCount { get; set; }

    public static PaginationDto Empty()
    {
        return new PaginationDto(totalCount: 0, page: 1, itemCount: 0);
    }
}