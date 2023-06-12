using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class PreviewControlBusinessModel : DefaultBusinessModel
{
    public PreviewControlBusinessModel(IServiceHub serviceHub) : base(serviceHub)
    {
        
    }

    internal void NewProject()
    {
        serviceHub.Get<IProjectControllerService>()?.CreateProject("Test Project");
    }

    internal void LoadProject()
    {
        serviceHub.Get<IProjectControllerService>()?.CreateProject("Test Project");
    }
}
