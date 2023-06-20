using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models.Database;
using _4alleach.MCRecipeEditor.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using System.Diagnostics;

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

        var stopwatch = new Stopwatch();

        stopwatch.Start();

        var insertResult = await databaseService!.Insert<Item>(new Item()
        {
            Id = Guid.NewGuid(),
            Name = "Test",
            Description = "Best test"
        }, CancellationToken.None);

        var items = await databaseService!.SelectAll<Item>(CancellationToken.None);

        var delResult = await databaseService!.Delete(items!, CancellationToken.None);

        stopwatch.Stop();
    }

    internal TService? GetService<TService>() where TService : class, IService
    {
        return serviceHub.Get<TService>();
    }
}
