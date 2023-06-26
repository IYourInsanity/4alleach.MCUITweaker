using _4alleach.MCRecipeEditor.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace _4alleach.MCRecipeEditor.Services;

public sealed class ServiceHub : IServiceHub
{
    public static readonly IServiceHub Instance;

    private IServiceProvider? _serviceProvider; 

    static ServiceHub()
    {
        var serviceHub = new ServiceHub();

        var serviceCollection = new ServiceCollection()
            .AddSingleton<IServiceHub>(serviceHub)
            .AddSingleton<IBusinessModelConstructService, BusinessModelConstructService>()
            .AddSingleton<IProjectControllerService, ProjectControllerService>()
            .AddSingleton<IDatabaseControllerService, DatabaseControllerService>()
            .AddSingleton<IAutoMapperService, AutoMapperService>();

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
