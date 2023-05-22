using System.Net;

namespace SubstationTracker.Application.Utilities.Responses.Abstracts;

public abstract class DataResponse<T> : Response, IDataResponse<T>
{
    protected DataResponse(string message, HttpStatusCode statusCode, bool ısSuccess, T data) : base(message,
        statusCode, ısSuccess)
    {
        Data = data;
    }

    public T Data { get; set; }
}