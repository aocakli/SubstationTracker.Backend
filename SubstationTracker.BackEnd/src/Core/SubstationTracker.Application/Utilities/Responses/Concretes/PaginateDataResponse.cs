using System.Collections;
using System.Net;
using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class PaginateDataResponse<T> : DataResponse<T>, IPaginateDataResponse<T>
    where T : IEnumerable
{
    public PaginateDataResponse(string message, bool isSuccess, T data, HttpStatusCode statusCode,
        PaginationDto pagination) : base(message,
        statusCode,
        isSuccess,
        data)
    {
        Pagination = pagination;
    }

    public PaginationDto Pagination { get; set; }
}