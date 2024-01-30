using Newtonsoft.Json;
using Products.Application.Common.Exceptions;
using System.Net;
using ValidationException = Products.Application.Common.Exceptions.ValidationException;

namespace Products.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await handleException(ex, context);
        }
    }

    private async Task handleException(Exception ex, HttpContext context)
    {
        context.Response.ContentType = "application/json";
        var status = HttpStatusCode.InternalServerError;
        object result = new { error = ex.Message };

        switch (ex)
        {
            case NotFoundException:
                status = HttpStatusCode.NotFound;
                break;
            case ValidationException validationException:
                status = HttpStatusCode.BadRequest;
                result = new { error = ex.Message, fields = validationException.Errors };
                break;
            default:
                break;
        }

        context.Response.StatusCode = (int)status;
        await context.Response.WriteAsJsonAsync(result);
    }
}
