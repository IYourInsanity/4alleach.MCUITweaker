namespace _4alleach.MCRecipeEditor.Client.Abstractions.Services;

internal interface IProjectControllerService : IService
{
    void CreateProject(string name);

    void LoadProject(string name);
}
