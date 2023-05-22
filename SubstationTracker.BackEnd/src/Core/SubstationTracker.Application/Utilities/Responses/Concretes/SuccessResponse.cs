using System.Net;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class SuccessResponse : Response
{
    public SuccessResponse(string message) : base(message, HttpStatusCode.OK, true)
    {
    }

    public SuccessResponse(string message, HttpStatusCode statusCode) : base(message, statusCode, true)
    {
    }
}