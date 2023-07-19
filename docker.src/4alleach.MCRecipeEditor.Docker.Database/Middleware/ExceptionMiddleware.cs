namespace _4alleach.MCRecipeEditor.Docker.Database.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorContent = new { Details = ex.Message};

            await context.Response.WriteAsJsonAsync(errorContent);
        }
    }
}
