using _4alleach.MCRecipeEditor.Models.CraftTweak.Abstractions;
using _4alleach.MCRecipeEditor.Models.CraftTweak.Enumerable;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models.Services.Project;

public sealed partial class RecipeProject : IdentityObject
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private RecipeType type;

    [ObservableProperty]
    private DefaultRecipe? recipe;

    public RecipeProject(string name) : base()
    {
        Name = name;
        Type = RecipeType.None;
    }
}
