namespace _4alleach.MCRecipeEditor.Docker.Database.Middleware;

public class TokenMiddleware
{
    private const string TOKEN = "E3155B56-0A8A-4FAA-9884-12A364ADAB97";

    private readonly RequestDelegate next;

    public TokenMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Cookies["token"];

        if (token?.Equals(TOKEN) == true)
        {
            await next.Invoke(context);
        }
        else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Token is invalid");
        }
    }
}
