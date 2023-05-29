using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels.Base;

internal abstract class DefaultBusinessModel : IDefaultBusinessModel
{
    protected IServiceHub serviceHub;

    protected DefaultBusinessModel(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }

    public abstract void Dispose();
}
