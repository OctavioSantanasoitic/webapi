
using System.Net;
using System.Text.Json;

namespace webapi;
public class ErrorHandlingMiddleware
{

    private readonly RequestDelegate Next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.Next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }

    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var code = HttpStatusCode.InternalServerError;

        if (ex is ArgumentNullException)
            code = HttpStatusCode.BadRequest;


        else if (ex is KeyNotFoundException)
            code = HttpStatusCode.NotFound;


        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(JsonSerializer.Serialize(new { errror = ex.Message }));
    }

}