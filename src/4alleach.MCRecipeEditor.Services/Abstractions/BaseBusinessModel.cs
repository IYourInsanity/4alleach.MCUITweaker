namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public abstract class BaseBusinessModel
{
    protected IServiceHub serviceHub;

    protected BaseBusinessModel(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }
}
