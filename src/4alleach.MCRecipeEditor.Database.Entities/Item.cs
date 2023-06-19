using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Data;


namespace _4alleach.MCRecipeEditor.Database.Entities;

public sealed class Item : Asset
{
    [DataName(nameof(Name))]
    [DbType(DbType.String)]
    public string? Name { get; set; }

    [DataName(nameof(Description))]
    [DbType(DbType.String)]
    public string? Description { get; set; }

    [ForeignKey]
    [DataName(nameof(ItemTypeId))]
    [DbType(DbType.Guid)]
    public Guid? ItemTypeId { get; set; }

    [ForeignKey]
    [DataName(nameof(ModTypeId))]
    [DbType(DbType.Guid)]
    public Guid? ModTypeId { get; set; }

    [ForeignKey]
    [DataName(nameof(ItemPrefixId))]
    [DbType(DbType.Guid)]
    public Guid? ItemPrefixId { get; set; }

    [ForeignKey]
    [DataName(nameof(ItemPostfixId))]
    [DbType(DbType.Guid)]
    public Guid? ItemPostfixId { get; set; }
}
