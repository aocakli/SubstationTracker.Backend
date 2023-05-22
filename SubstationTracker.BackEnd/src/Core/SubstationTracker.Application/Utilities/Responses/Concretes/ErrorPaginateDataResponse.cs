using System.Collections;
using System.Net;
using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class ErrorPaginateDataResponse<T> : PaginateDataResponse<T>
    where T : IEnumerable
{
    public ErrorPaginateDataResponse(string message, T data, HttpStatusCode statusCode,
        PaginationDto pagination) : base(message, false, data, statusCode, pagination)
    {
    }

    public ErrorPaginateDataResponse(string message, T data,
        PaginationDto pagination) : this(message, data, HttpStatusCode.OK, pagination)
    {
    }

    public ErrorPaginateDataResponse(string message) : this(message, default, HttpStatusCode.OK, null)
    {
    }
}