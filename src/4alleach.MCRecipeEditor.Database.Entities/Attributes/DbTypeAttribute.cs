using System.Data;

namespace _4alleach.MCRecipeEditor.Database.Entities.Attributes;

public class DbTypeAttribute : Attribute
{
    protected DbType _value { get; set; }

    public DbType Value
    {
        get => _value;
        set => _value = value;
    }

    public DbTypeAttribute()
    {
        _value = DbType.Binary;
    }

    public DbTypeAttribute(DbType value)
    {
        _value = value;
    }
}
