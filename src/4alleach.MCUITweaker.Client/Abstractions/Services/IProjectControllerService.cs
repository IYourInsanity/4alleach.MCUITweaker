using _4alleach.MCRecipeEditor.Models.Services.Project;

namespace _4alleach.MCRecipeEditor.Client.Abstractions.Services;

internal interface IProjectControllerService : IService
{
    void CreateProject(string name);
    void SaveProject();
    void LoadProject();

    void CreateFileProject(string name);
    void DeleteFileProject(string name);

    void CreateRecipeProject(Guid fileId, string recipeName);
    void DeleteRecipeProject(Guid fileId, string recipeName);

    FileProject? FindFileProject(Guid id);
    RecipeProject? FindRecipeProject(Guid id);

    IList<FileProject>? GetAllFileProjects();
    IList<RecipeProject>? GetAllRecipeProjects(Guid id);
}
