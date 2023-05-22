namespace SubstationTracker.Application.Utilities.Paginations;

public interface IPaginationRequest
{
    public PaginationRequestBase Pagination { get; set; }
}