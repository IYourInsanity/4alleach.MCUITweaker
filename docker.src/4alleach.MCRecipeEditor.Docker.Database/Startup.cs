using _4alleach.MCRecipeEditor.Database;
using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
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
        services.AddDbContext<IAssetsContext, AssetsContext>();

        services.AddControllers();
        services.AddHttpContextAccessor();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Todo API", Description = "Keep track of your tasks", Version = "v1" });
        });

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

        app.UseMiddleware<ExceptionMiddleware>();
        //app.UseMiddleware<TokenMiddleware>();

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.UseRouting();

        app.UseEndpoints(epBuilder =>
        {
            epBuilder.MapControllers();
        });

        app.UseMvc();
    }
}
