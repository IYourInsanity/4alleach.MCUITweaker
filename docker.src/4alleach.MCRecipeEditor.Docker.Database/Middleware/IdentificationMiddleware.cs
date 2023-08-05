namespace _4alleach.MCRecipeEditor.Docker.Database.Middleware;

public sealed class IdentificationMiddleware
{
    private const string Key = "E3155B56-0A8A-4FAA-9884-12A364ADAB97";

    private readonly RequestDelegate next;

    public IdentificationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.Path.Value?.Contains("graphql") == true)
        {
            await next.Invoke(context);
            return;
        }

        var value = context.Request.Cookies[nameof(Key)];

        if (value?.Equals(Key) == true)
        {
            await next.Invoke(context);
        }
        else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Key is invalid.");
        }
    }
}
