using _4alleach.MCRecipeEditor.Models.Database.Base;

namespace _4alleach.MCRecipeEditor.Models.Database;

public sealed class ModType : Asset
{
    public string? FullName { get; set; }
    public string? ShortName { get; set; }
}
