namespace _4alleach.MCRecipeEditor.Client.UIExtension.Components;

[AttributeUsage(AttributeTargets.All)]
public sealed class IdAttribute : Attribute
{
    public static readonly IdAttribute Default = new ();

    #region Constructors

    public IdAttribute() : this(-1)
    {
    }

    public IdAttribute(int Id)
    {
        IdValue = Id;
    }

    #endregion

    #region Properties

    public int Id => IdValue;

    private int IdValue { get; set; }

    #endregion

    #region Overrides of Attribute

    public override bool IsDefaultAttribute()
    {
        return Equals(Default);
    }

    #endregion

    #region Overrides of Object

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

    #endregion
}
