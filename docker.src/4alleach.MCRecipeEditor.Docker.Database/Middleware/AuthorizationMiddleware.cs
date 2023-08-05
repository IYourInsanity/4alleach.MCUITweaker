using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.Middleware;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate next;

    public AuthorizationMiddleware(RequestDelegate next)
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

        var value = context.Items[nameof(Account.AccessLevel)];

        if (value is AccessLevel accessLevel)
        {
            switch (accessLevel)
            {
                case AccessLevel.Read:



                    break;
                case AccessLevel.All:



                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            await next.Invoke(context);
        }
        else
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access level is invalid.");
        }
    }
}
