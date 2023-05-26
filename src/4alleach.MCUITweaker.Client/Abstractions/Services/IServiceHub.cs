namespace _4alleach.MCUITweaker.Client.Abstractions.Services;

internal interface IServiceHub : IService
{
    void Register<TService, TServiceImplementation>() 
        where TService : IService
        where TServiceImplementation : class, IService;

    TService? Get<TService>() where TService : class, IService;
}
