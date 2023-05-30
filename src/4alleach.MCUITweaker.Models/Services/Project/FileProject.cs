using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public sealed partial class FileProject : IdentityObject
{
    [ObservableProperty]
    string name;

    [ObservableProperty]
    IList<RecipeProject> recipes;

    public FileProject(string name, IList<RecipeProject> recipes) : base()
    {
        Name = name;
        Recipes = recipes;
    }
}
