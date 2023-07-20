using Microsoft.AspNetCore;

namespace _4alleach.MCRecipeEditor.Docker.Database;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args)
            .Build()
            .Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>();

}
