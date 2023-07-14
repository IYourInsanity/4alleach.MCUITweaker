using _4alleach.MCRecipeEditor.Client.Abstractions.BusinessModel;
using _4alleach.MCRecipeEditor.Communication.Models;
using _4alleach.MCRecipeEditor.Models.Database;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : BaseBusinessModel
{
    internal MainWindowBusinessModel() : base()
    {

    }

    internal async void Initialize()
    {
        var service = serviceHub.Get<ICommunicationService>();

        using var handler = service.Use(ProviderType.Database).UseHandler<Item>();

        var item = new Item()
        {
            Id = Guid.NewGuid(),
            Name = "Fire",
            Description = "Flame"
        };

        //await handler.InsertAsync(item, CancellationToken.None);

        var result = await handler.SelectWithConditionAsync("Name == \"Fire\"", CancellationToken.None);
    }
}
