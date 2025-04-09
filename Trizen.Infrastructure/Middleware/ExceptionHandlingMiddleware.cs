using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using Trizen.Infrastructure.Exceptions;

namespace Trizen.Infrastructure.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        switch (exception)
        {
            case DatabaseRecordNotFoundException ex:
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                _logger.LogError(ex, "Database Record Not Found Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/NotFoundError");
                break;
            case DatabaseInvalidDataException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError(ex, "Database Invalid Data Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            case DatabaseFailException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError(ex, "Database Fail Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            case DatabaseForeignKeyException ex:
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                _logger.LogError(ex, "Database Foreign Key Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            case BusinessDuplicateException ex:
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;
                _logger.LogError(ex, "Business Duplicate Data Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            case BusinessRuleException ex:
                context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                _logger.LogError(ex, "Business Rule Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            case BusinessFailException ex:
                context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
                _logger.LogError(ex, "Business Fail Exception: {Message}", ex.Message);
                context.Response.HttpContext.Response.Redirect("/Error/BadRequestError");
                break;
            default:
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError(exception, "An Unhandled Exception Occurred: {Message}", exception.Message);
                context.Response.HttpContext.Response.Redirect("/Error/InternalServerError");
                break;
        }

        await _next(context);
    }
}