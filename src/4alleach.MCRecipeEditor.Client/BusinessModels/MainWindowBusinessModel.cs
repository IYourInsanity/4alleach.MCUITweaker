using _4alleach.MCRecipeEditor.Client.Abstractions.BusinessModel;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MainWindowBusinessModel : BaseBusinessModel
{
    internal MainWindowBusinessModel() : base()
    {

    }

    internal void Initialize()
    {
        var databaseService = serviceHub.Get<IDatabaseControllerService>();
    }
}
