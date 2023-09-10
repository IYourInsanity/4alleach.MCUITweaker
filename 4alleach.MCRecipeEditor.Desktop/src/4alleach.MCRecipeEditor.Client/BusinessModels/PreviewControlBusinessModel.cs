using _4alleach.MCRecipeEditor.Client.Abstractions.BusinessModel;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class PreviewControlBusinessModel : BaseBusinessModel
{
    internal PreviewControlBusinessModel() : base() { }

    internal void NewProject()
    {
        serviceHub.Get<IProjectControllerService>()?.CreateProject("Test Project");
    }

    internal void LoadProject()
    {
        serviceHub.Get<IProjectControllerService>()?.CreateProject("Test Project");
    }
}
