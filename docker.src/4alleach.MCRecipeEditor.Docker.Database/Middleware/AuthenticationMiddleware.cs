using _4alleach.MCRecipeEditor.Docker.Database.Core;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;

namespace _4alleach.MCRecipeEditor.Docker.Database.Middleware;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context, [Service] AssetsContext dbContext)
    {
        if (context.Request.Path.Value?.Contains("graphql") == true)
        {
            await next.Invoke(context);
            return;
        }

        var login = string.Empty;
        var password = string.Empty;

        login = context.Request.Cookies[nameof(login)];
        password = context.Request.Cookies[nameof(password)];

        var result = dbContext.BuildRepository<AccountRepository, Account>()
                                   .SelectAllAsQueryable()?
                                   .Any(_ => _.Login.Equals(login) && _.Password.Equals(password));

        //if (result != null)
        //{
        //    context.Items[nameof(Account.AccessLevel)] = result.AccessLevel;
        //    await next.Invoke(context);
        //}
        //else
        //{
        //    context.Response.StatusCode = 403;
        //    await context.Response.WriteAsync("Account is invalid.");
        //}
    }
}
