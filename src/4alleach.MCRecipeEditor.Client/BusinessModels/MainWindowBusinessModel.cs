using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Mapper.Extensions;
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

    internal void Initialize()
    {
        var bmConstructService = serviceHub.Get<IBusinessModelConstructService>();

        bmConstructService?.Register<PreviewControlBusinessModel>(nameof(PreviewControl));
        bmConstructService?.Register<MenuControlBusinessModel>(nameof(MenuControl));

        var databaseService = serviceHub.Get<IDatabaseControllerService>()!;

        var itemType = new ItemType() { Id = Guid.NewGuid(), Value = "Fluid" };
        var item = new Item() { Id = Guid.NewGuid(), Name = "Water", Description = "H20 just add", ItemTypeId = itemType.Id };

        var stopWatch = new Stopwatch();

        stopWatch.Start();

        //databaseService!.CreateProvider(provider =>
        //{
        //    provider.Map(itemType)
        //            .UseContext((context, type, mapped) =>
        //            {
        //                context.CreateHandler(type).Insert(mapped!);
        //            });

        //    provider.Map(item)
        //            .UseContext((context, type, mapped) =>
        //            {
        //                context.CreateHandler(type).Insert(mapped!);
        //            });
        //});

        var models = default(IEnumerable<Item>);

        databaseService!.CreateProvider(provider =>
        {
            provider.UseHandler<Item>(handler =>
            {
                var entities = handler.SelectAll()!;

                models = provider.Map<Item>(entities);

            });
        });

        stopWatch.Stop();

    }

    internal TService? GetService<TService>() 
        where TService : class, IService
    {
        return serviceHub.Get<TService>();
    }
}
