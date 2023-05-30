using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.BusinessModels.Base;
using _4alleach.MCRecipeEditor.Models.Services.Project;

namespace _4alleach.MCRecipeEditor.Client.BusinessModels;

internal sealed class MenuControlBusinessModel : DefaultBusinessModel
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

    public override void Dispose()
    {
        throw new NotImplementedException();
    }
}
