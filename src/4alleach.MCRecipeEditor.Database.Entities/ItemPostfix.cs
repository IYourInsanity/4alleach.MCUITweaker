using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;

namespace _4alleach.MCRecipeEditor.Database.Entities;

public class ItemPostfix : Asset
{
    [DataName(nameof(Value))]
    [DbType(DbType.String)]
    public string? Value { get; set; }
}
