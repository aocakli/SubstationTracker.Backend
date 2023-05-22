using System.Net;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class ErrorDataResponse<T> : DataResponse<T>
{
    public ErrorDataResponse(IResponse response) : this(message: response.Message, statusCode: response.StatusCode,
        data: default)
    {
    }

    public ErrorDataResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : this(
        message: message, statusCode: statusCode,
        data: default)
    {
    }

    public ErrorDataResponse(string message, HttpStatusCode statusCode, T data) : base(message, statusCode, false,
        data)
    {
    }
}