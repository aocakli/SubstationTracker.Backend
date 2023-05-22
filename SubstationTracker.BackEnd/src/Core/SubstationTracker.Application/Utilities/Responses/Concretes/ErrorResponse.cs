using System.Net;
using SubstationTracker.Application.Utilities.Responses.Abstracts;

namespace SubstationTracker.Application.Utilities.Responses.Concretes;

public class ErrorResponse : Response
{
    public ErrorResponse(string message, HttpStatusCode statusCode, List<KeyValuePair<string, string>> validationErrors)
        : base(message, statusCode, false)
    {
        ValidationErrors = validationErrors;
    }

    public ErrorResponse(string message, HttpStatusCode statusCode) : this(message, statusCode, null)
    {
    }
    
    public ErrorResponse(string message) : this(message, HttpStatusCode.BadRequest, null)
    {
    }
    
    public ErrorResponse(IResponse response) : this(response.Message, response.StatusCode, null)
    {
    }

    public List<KeyValuePair<string, string>> ValidationErrors { get; set; }
}