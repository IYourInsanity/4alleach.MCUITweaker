using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Database.Provider.Extensions;
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

        var databaseService = serviceHub.Get<IDatabaseControllerService>()!;

        var itemType = new ItemType() { Id = Guid.NewGuid(), Value = "Fluid" };
        var item = new Item() { Id = Guid.NewGuid(), Name = "Water", Description = "H20 just add", ItemTypeId = itemType.Id };

        var stopWatch = new Stopwatch();

        stopWatch.Start();

        var Items = default(IEnumerable<Item>);
        var ItemTypes = default(IEnumerable<ItemType>);
        var ModTypes = default(IEnumerable<ModType>);

        using (var provider = databaseService.CreateProvider())
        {
            await provider.UseHandlerAsync<Item>((handler, token) =>
            {
                Items = handler.SelectAll();

            }, CancellationToken.None);

            await provider.UseHandlerAsync<ItemType>((handler, token) =>
            {
                ItemTypes = handler.SelectAll();

            }, CancellationToken.None);

            await provider.UseHandlerAsync<ModType>((handler, token) =>
            {
                ModTypes = handler.SelectAll();

            }, CancellationToken.None);
        }

        stopWatch.Stop();
    }

    internal TService? GetService<TService>() 
        where TService : class, IService
    {
        return serviceHub.Get<TService>();
    }
}
