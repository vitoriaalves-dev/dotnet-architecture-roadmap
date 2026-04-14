using System.Net;
using System.Text.Json;
using EcommerceApp.Domain.Exceptions;

namespace EcommerceApp.Adapters.Outbound.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            await HandleDomainExceptionAsync(context, ex);
        }
        catch (Exception)
        {
            await HandleUnexpectedExceptionAsync(context);
        }
    }

    private static Task HandleDomainExceptionAsync(HttpContext context, DomainException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var response = new
        {
            error = ex.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleUnexpectedExceptionAsync(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var response = new
        {
            error = "Erro interno inesperado"
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}