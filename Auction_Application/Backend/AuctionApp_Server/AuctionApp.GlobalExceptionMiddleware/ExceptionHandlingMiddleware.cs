using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace AuctionApp.GlobalMiddleware;

/// <summary>
/// Middleware to handle global exception
/// </summary>
/// <param name="next"></param>
public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception) 
        {
            var exceptionResponse = new
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server Error",
                ErrorMessage = exception.Message
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            string jsonResponse = JsonSerializer.Serialize(exceptionResponse);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
