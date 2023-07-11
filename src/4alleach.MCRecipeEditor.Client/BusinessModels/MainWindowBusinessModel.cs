using _4alleach.MCRecipeEditor.Client.Abstractions.BusinessModel;
using _4alleach.MCRecipeEditor.Database.Provider.Extensions;
using _4alleach.MCRecipeEditor.Models.Database;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using _4alleach.MCRecipeEditor.Common.Extensions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : BaseBusinessModel
{
    internal MainWindowBusinessModel() : base()
    {

    }

    internal async void Initialize()
    {
        serviceHub.Get<IDatabaseControllerService>().PreloadDatabase();
    }
}
