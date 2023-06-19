using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;

namespace _4alleach.MCRecipeEditor.Database.Entities.Abstractions;

public abstract class Asset
{
    [DataName(nameof(Id))]
    [DbType(DbType.Guid)]
    public Guid Id { get; set; }
}
