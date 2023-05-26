using _4alleach.MCUITweaker.Client.Abstractions.Services;
using _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

namespace _4alleach.MCUITweaker.Client.BusinessModels;

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
