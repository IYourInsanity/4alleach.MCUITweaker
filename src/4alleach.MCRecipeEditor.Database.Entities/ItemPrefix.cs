using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities;

[EntityTypeConfiguration(typeof(ItemPrefixConfiguration))]
public class ItemPrefix : Asset
{
    public string? Value { get; set; }

    public List<Item> Items { get; set; } = new();
}
