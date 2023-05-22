using System.Collections;
using System.Net;
using SubstationTracker.Application.Utilities.Paginations;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class SuccessPaginateDataResponse<T> : PaginateDataResponse<T>
    where T : IEnumerable
{
    public SuccessPaginateDataResponse(string message, T data, HttpStatusCode statusCode,
        PaginationDto pagination) : base(message, true, data, statusCode, pagination)
    {
    }

    public SuccessPaginateDataResponse(string message, T data,
        PaginationDto pagination) : this(message, data, HttpStatusCode.OK, pagination)
    {
    }
}