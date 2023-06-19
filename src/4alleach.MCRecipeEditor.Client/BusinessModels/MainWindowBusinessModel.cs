using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Database.Entities;
using _4alleach.MCRecipeEditor.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : BaseBusinessModel
{
    internal MainWindowBusinessModel() : base(ServiceHub.Instance)
    {

    }

    internal async void Initialize()
    {
        var bmConstructService = serviceHub.Get<IBusinessModelConstructService>();

        bmConstructService?.Register<PreviewControlBusinessModel>(nameof(PreviewControl));
        bmConstructService?.Register<MenuControlBusinessModel>(nameof(MenuControl));

        var databaseService = serviceHub.Get<IDatabaseControllerService>();
    }

    internal TService? GetService<TService>() where TService : class, IService
    {
        return serviceHub.Get<TService>();
    }
}
