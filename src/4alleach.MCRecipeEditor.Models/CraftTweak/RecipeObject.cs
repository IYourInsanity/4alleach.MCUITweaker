using _4alleach.MCRecipeEditor.Models.CraftTweak.Enumerable;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Models.CraftTweak;

public sealed partial class RecipeObject : IdentityObject
{
    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private RecipeObjectType type;

    public RecipeObject() : base()
    {
        name = string.Empty;
        type = RecipeObjectType.None;
    }

    public RecipeObject(string name, RecipeObjectType type) : base()
    {
        this.name = name;
        this.type = type;
    }
}
