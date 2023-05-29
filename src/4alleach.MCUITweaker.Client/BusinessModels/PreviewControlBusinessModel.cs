using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.BusinessModels.Base;

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

    public override void Dispose()
    {
        throw new System.NotImplementedException();
    }
}
