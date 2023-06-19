using _4alleach.MCRecipeEditor.Database.Abstractions;

namespace _4alleach.MCRecipeEditor.Database;

public sealed class Entry
{
    public static IDatabaseContext CreateContext()
    {
        return new DatabaseContext();
    }
}
