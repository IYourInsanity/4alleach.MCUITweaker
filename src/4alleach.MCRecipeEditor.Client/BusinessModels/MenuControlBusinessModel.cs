using _4alleach.MCRecipeEditor.Models.Services.Project;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MenuControlBusinessModel : BaseBusinessModel
{
    private const string NEW_PROJECT = "New Project";
    private const string NEW_RECIPE = "New Recipe";

    private IProjectControllerService? projectService;

    internal IList<FileProject>? FileCollection => projectService?.GetAllFileProjects();

    internal FileProject? selectedFileProject;

    internal IList<RecipeProject>? RecipeCollection => selectedFileProject?.Recipes;

    internal RecipeProject? selectedRecipeProject;

    public MenuControlBusinessModel(IServiceHub serviceHub) : base(serviceHub)
    {

    }

    internal void Initialize()
    {
        projectService = serviceHub.Get<IProjectControllerService>();
    }

    internal void AddNewFile()
    {
        projectService?.CreateFileProject(NEW_PROJECT);
    }

    internal void AddNewRecipe()
    {
        if(selectedFileProject == null)
        {
            return;
        }

        projectService?.CreateRecipeProject(selectedFileProject.Id, NEW_RECIPE);
    }
}
