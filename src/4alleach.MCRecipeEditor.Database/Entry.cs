using _4alleach.MCRecipeEditor.Database.Abstractions;

namespace _4alleach.MCRecipeEditor.Database;

public static class Entry
{
    public static IDbContext CreateContext()
    {
        return new DatabaseContext();
    }
}
