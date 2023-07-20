using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

[EntityTypeConfiguration(typeof(ItemTypeConfiguration))]
public class ItemType : Asset
{
    public string? Value { get; set; }

    public List<Item> Items { get; set; } = new();
}
