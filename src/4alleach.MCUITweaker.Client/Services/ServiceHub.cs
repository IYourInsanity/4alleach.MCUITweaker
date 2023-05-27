using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace _4alleach.MCRecipeEditor.Client.Services;

internal sealed class ServiceHub : IServiceHub
{
    private readonly ConcurrentDictionary<Type, IService> storage;

    internal ServiceHub()
    {
        storage = new ConcurrentDictionary<Type, IService>();
    }

    public void Initialize()
    {
        foreach (var service in storage.Values)
        {
            service.Initialize();
        }
    }

    public void Register<TService, TServiceImplementation>() 
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
