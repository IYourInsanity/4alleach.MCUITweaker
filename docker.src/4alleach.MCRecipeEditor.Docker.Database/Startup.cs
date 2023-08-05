using _4alleach.MCRecipeEditor.Docker.Database.Core;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.GraphQL.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Helper;
using _4alleach.MCRecipeEditor.Docker.Database.Middleware;
using Microsoft.OpenApi.Models;

namespace _4alleach.MCRecipeEditor.Docker.Database;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
        });

        ConfigureGraphQl(services);
        ConfigureDatabase(services);

        services.AddMvc(opt => opt.EnableEndpointRouting = false);
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        //app.UseStaticFiles(); Not needed in current project

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
        });

        ConfigureMiddleware(app);

        //app.UseMiddleware<TokenMiddleware>();

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.UseRouting();
        app.UseEndpoints(epBuilder =>
        {
            epBuilder.MapControllers();
            epBuilder.MapGraphQL("/graphql");
        });

        app.UseMvc();
    }

    private void ConfigureGraphQl(IServiceCollection services)
    {
        var builder = services.AddGraphQLServer();

        builder.AddQueryType(q => q.Name(nameof(Queries)));

        foreach (var type in ReflectionHelper.GetAssignableFromType<IQueries>())
        {
            builder.AddType(type);
        }

        builder.AddProjections()
               .AddFiltering()
               .AddSorting();
    }

    private void ConfigureDatabase(IServiceCollection services)
    {
        services.AddSingleton<IRepositoryCollection, RepositoryCollection>();
        services.AddDbContext<IAssetsContext, AssetsContext>();
    }

    private void ConfigureMiddleware(IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        //app.UseMiddleware<IdentificationMiddleware>();
        //app.UseMiddleware<AuthenticationMiddleware>();
        //app.UseMiddleware<AuthorizationMiddleware>();
    }
}
