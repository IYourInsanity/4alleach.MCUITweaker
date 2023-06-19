namespace _4alleach.MCRecipeEditor.Database.Entities.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class DataNameAttribute : Attribute
{
    protected string _value { get; set; }

    public string Value
    {
        get => _value;
        set => _value = value;
    }

    public DataNameAttribute()
    {
        _value = string.Empty;
    }

    public DataNameAttribute(string value)
    {
        _value = value;
    }
}
