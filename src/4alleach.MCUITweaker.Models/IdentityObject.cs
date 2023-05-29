namespace _4alleach.MCRecipeEditor.Models;
public record IdentityObject
{
    public Guid ID
    {
        get;
        init;
    }

    protected IdentityObject()
    {
        ID = Guid.NewGuid();
    }
}
