using _4alleach.MCRecipeEditor.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace _4alleach.MCRecipeEditor.Services;

internal sealed class ServiceHub : IServiceHub
{
    internal static readonly IServiceHub Instance;

    private IServiceProvider? _serviceProvider; 

    static ServiceHub()
    {
        var serviceHub = new ServiceHub();

        var serviceCollection = new ServiceCollection()
            .AddSingleton<IServiceHub>(serviceHub)
            .AddSingleton<IProjectControllerService, ProjectControllerService>()
            .AddSingleton<IDatabaseControllerService, DatabaseControllerService>();

        serviceHub.Initialize(serviceCollection);

        Instance = serviceHub;
    }

    private void Initialize(IServiceCollection collection)
    {
        _serviceProvider = collection.BuildServiceProvider();
    }

    public TService? Get<TService>() where TService : class, IService
    {
        var service = _serviceProvider?.GetService<TService>();

        service?.Initialize();

        return service;
    }
}
