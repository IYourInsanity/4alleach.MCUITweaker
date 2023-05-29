using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.BusinessModels.Base;
using _4alleach.MCRecipeEditor.Client.Services;
using _4alleach.MCRecipeEditor.Client.Views.Controls;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : DefaultBusinessModel
{
    internal MainWindowBusinessModel() : base(new ServiceHub())
    {

    }

    internal void Initialize()
    {
        serviceHub.Register<IBusinessModelConstructService, BusinessModelConstructService>();
        serviceHub.Register<IProjectControllerService, ProjectControllerService>();

        serviceHub.Initialize();

        var bmConstructService = serviceHub.Get<IBusinessModelConstructService>();

        bmConstructService?.Register<PreviewControlBusinessModel>(nameof(PreviewControl));
        bmConstructService?.Register<MenuControlBusinessModel>(nameof(MenuControl));
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

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }
}
