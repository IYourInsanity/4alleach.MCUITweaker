using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Models.Services.Project;

namespace _4alleach.MCRecipeEditor.Client.Services;

internal sealed class ProjectControllerService : IProjectControllerService
{
    private AppProject? project;
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
        project = new AppProject(name, new List<FileProject>());
    }

    public void SaveProject()
    {
        throw new NotImplementedException();
    }

    public void LoadProject()
    {
        throw new System.NotImplementedException();
    }

    public void CreateFileProject(string name)
    {
        project?.Files.Add(new FileProject(name, new List<RecipeProject>()));
    }

    public void DeleteFileProject(string name)
    {
        throw new NotImplementedException();
    }

    public void CreateRecipeProject(Guid fileId, string recipeName)
    {
        if (project == null) 
        {
            throw new NotImplementedException();
        }

        var file = project.Files.Where(_ => _.Id.Equals(fileId)).FirstOrDefault();

        if (file == null)
        {
            throw new NotImplementedException();
        }

        file.Recipes.Add(new RecipeProject(recipeName));
    }

    public void DeleteRecipeProject(Guid fileId, string recipeName)
    {
        throw new NotImplementedException();
    }

    public FileProject? FindFileProject(Guid id)
    {
        if(project == null)
        {
            throw new NotImplementedException();
        }

        return project.Files.Where(_ => _.Id.Equals(id)).FirstOrDefault();
    }

    public RecipeProject? FindRecipeProject(Guid id)
    {
        if (project == null)
        {
            throw new NotImplementedException();
        }

        var files = project.Files;

        foreach(var file in files)
        {
            if(file == null)
            {
                throw new NotImplementedException();
            }

            return file.Recipes.Where(_ => _.Id.Equals(id)).FirstOrDefault();
        }

        throw new NotImplementedException();
    }

    public IList<FileProject>? GetAllFileProjects()
    {
        if (project == null)
        {
            throw new NotImplementedException();
        }

        return project.Files;
    }

    public IList<RecipeProject>? GetAllRecipeProjects(Guid id)
    {
        return FindFileProject(id)?.Recipes;
    }
}
