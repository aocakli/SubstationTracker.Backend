using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SubstationTracker.Application.Utilities.Exceptions;
using SubstationTracker.Application.Utilities.Responses.Concretes;
using ValidationException = SubstationTracker.Application.Utilities.Exceptions.ValidationException;

namespace SubstationTracker.Application.Utilities.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        ErrorResponse response = null;

        if (exception is Exceptions.ValidationException validationException)
            response = new ErrorResponse("Bazı alanlarda veriler eksik. Lütfen bilgileri kontrol edip tekrar dene.",
                HttpStatusCode.BadRequest, validationException.ValidationErrors);
        else if (exception is BusinessException businessException)
            response = new ErrorResponse(businessException.Message, HttpStatusCode.BadRequest, null);
        else if (exception is ErrorException errorException)
        {
            response = new ErrorResponse(errorException.Message, HttpStatusCode.InternalServerError, null);
            
            _logger.LogError(exception: exception, message: exception.Message);
        }
        else
        {
            response = new ErrorResponse("Bilinmeyen bir hata oluştu: " + exception.Message,
                HttpStatusCode.InternalServerError, null);

            _logger.LogError(exception: exception, message: exception.Message);
        }

        httpContext.Response.StatusCode = (int)response.StatusCode;

        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response,
            new JsonSerializerOptions(JsonSerializerDefaults.Web)));
    }
}