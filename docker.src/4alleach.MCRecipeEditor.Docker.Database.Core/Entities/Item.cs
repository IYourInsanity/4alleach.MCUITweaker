using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

[EntityTypeConfiguration(typeof(ItemConfiguration))]
public class Item : Asset
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public Guid? ItemTypeId { get; set; }
    public ItemType? ItemType { get; set; }

    public Guid? ModTypeId { get; set; }
    public ModType? ModType { get; set; }

    public Guid? ItemPrefixId { get; set; }
    public ItemPrefix? ItemPrefix { get; set; }

    public Guid? ItemPostfixId { get; set; }
    public ItemPostfix? ItemPostfix { get; set; }
}
