using System.ComponentModel.DataAnnotations;

namespace ReactiveRectangle.Api.Middleware;

public class GlobalExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException e)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new {message = e.Message});
        }
        catch (Exception e)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new {message = "An unexpected error occurred."});
        }
    }
}