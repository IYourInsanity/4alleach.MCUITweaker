using _4alleach.MCRecipeEditor.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.Abstractions.BusinessModel;

public abstract class BaseBusinessModel
{
    protected IServiceHub serviceHub;

    protected BaseBusinessModel()
    {
        serviceHub = ServiceEntry.Instance;
    }
}
