namespace _4alleach.MCRecipeEditor.Client.UIExtension.Components;

[AttributeUsage(AttributeTargets.All)]
public sealed class IdAttribute : Attribute
{
    public static readonly IdAttribute Default = new ();

    public int Id => Value;

    private int Value { get; set; }

    public IdAttribute() : this(-1) { }

    public IdAttribute(int Id)
    {
        Value = Id;
    }

    public override bool IsDefaultAttribute()
    {
        return Equals(Default);
    }

    public override bool Equals(object? obj)
    {
        if (obj == this)
        {
            return true;
        }

        var IdAttribute = obj as IdAttribute;
        return IdAttribute?.Id == Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
