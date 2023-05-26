using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.Services;
using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;
using _4alleach.MCUITweaker.Client.Views.Control;

namespace _4alleach.MCUITweaker.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : IDefaultBusinessModel
{
    private readonly IServiceHub serviceHub;

    internal MainWindowBusinessModel()
    {
        serviceHub = new ServiceHub();
    }

    internal void Initialize()
    {


        serviceHub.Register<IBusinessModelConstructService, BusinessModelConstructService>();
        serviceHub.Register<IProjectControllerService, ProjectControllerService>();

        serviceHub.Initialize();

        var bmConstructService = serviceHub.Get<IBusinessModelConstructService>();

        bmConstructService?.Register<PreviewControlBusinessModel>(nameof(PreviewControl));
    }

    internal void RegisterService<TService, TServiceImplementation>() 
        where TService : IService
        where TServiceImplementation : class, IService
    {
        serviceHub.Register<TService, TServiceImplementation>();
    }

    internal TService? GetService<TService>() where TService : class, IService
    {
        return serviceHub.Get<TService>();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }
}
