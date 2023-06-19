using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;

namespace _4alleach.MCRecipeEditor.Database.Entities;
public class ModType : Asset
{
    [DataName(nameof(FullName))]
    [DbType(DbType.String)]
    public string? FullName { get; set; }

    [DataName(nameof(ShortName))]
    [DbType(DbType.String)]
    public string? ShortName { get; set; }
}
