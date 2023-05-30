using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public sealed partial class RecipeProject : IdentityObject
{
    [ObservableProperty]
    string name;

    public RecipeProject(string name) : base()
    {
        Name = name;
    }
}
