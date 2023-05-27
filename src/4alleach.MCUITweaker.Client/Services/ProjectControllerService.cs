using _4alleach.MCRecipeEditor.Client.Abstractions.Services;

namespace _4alleach.MCRecipeEditor.Client.Services;

internal sealed class ProjectControllerService : IProjectControllerService
{
    private readonly IServiceHub serviceHub;

    public ProjectControllerService(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }

    public void Initialize()
    {
        
    }

    public void CreateProject(string name)
    {
        throw new System.NotImplementedException();
    }

    public void LoadProject(string name)
    {
        throw new System.NotImplementedException();
    }
}
