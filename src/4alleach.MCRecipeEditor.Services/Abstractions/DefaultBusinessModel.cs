namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public abstract class DefaultBusinessModel
{
    protected IServiceHub serviceHub;

    protected DefaultBusinessModel(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }
}
