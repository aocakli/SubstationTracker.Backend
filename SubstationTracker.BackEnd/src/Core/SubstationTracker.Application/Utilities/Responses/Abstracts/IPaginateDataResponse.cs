using System.Collections;
using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Utilities.Responses.Abstracts;

public interface IPaginateDataResponse<T> : IDataResponse<T>
    where T : IEnumerable
{
    public PaginationDto Pagination { get; set; }
}