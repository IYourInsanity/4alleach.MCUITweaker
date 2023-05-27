using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class PreviewControlBusinessModel : IDefaultBusinessModel
{
    private readonly IServiceHub serviceHub;

    public PreviewControlBusinessModel(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }

    internal void NewProject()
    {
        throw new System.NotImplementedException();
    }

    internal void LoadProject()
    {
        //throw new System.NotImplementedException();
    }

    public void Dispose()
    {
        throw new System.NotImplementedException();
    }


}
