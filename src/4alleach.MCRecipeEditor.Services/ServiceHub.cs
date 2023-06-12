using _4alleach.MCRecipeEditor.Services.Abstractions;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Services;

public sealed class ServiceHub : IServiceHub
{
    private readonly ConcurrentDictionary<Type, IService> storage;

    public static readonly IServiceHub Instance;

    static ServiceHub()
    {
        var serviceHub = new ServiceHub();

        serviceHub.Register<IBusinessModelConstructService, BusinessModelConstructService>();
        serviceHub.Register<IProjectControllerService, ProjectControllerService>();

        serviceHub.Initialize();

        Instance = serviceHub;
    }

    private ServiceHub()
    {
        storage = new ConcurrentDictionary<Type, IService>();
    }

    private void Initialize()
    {
        foreach (var service in storage.Values)
        {
            service.Initialize();
        }
    }

    private void Register<TService, TServiceImplementation>() 
        where TService : IService
        where TServiceImplementation : class, IService
    {
        var type = typeof(TServiceImplementation);
        var implementation = Activator.CreateInstance(type, this) as TServiceImplementation;

        storage.TryAdd(typeof(TService), implementation!);  
    }

    public TService? Get<TService>()
        where TService : class, IService
    {
        if(storage.TryGetValue(typeof(TService), out var service))
        {
            return service as TService;
        }

        return default;
    }


}
