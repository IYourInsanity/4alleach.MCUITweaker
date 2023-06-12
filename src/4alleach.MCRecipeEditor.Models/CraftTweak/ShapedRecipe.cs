using _4alleach.MCRecipeEditor.Models.CraftTweak.Abstractions;

namespace _4alleach.MCRecipeEditor.Models.CraftTweak;

public sealed partial class ShapedRecipe : DefaultRecipe
{
    private const int DEFAULT_SIZE = 9;

    public ShapedRecipe() : base(DEFAULT_SIZE)
    {
        
    }
}
