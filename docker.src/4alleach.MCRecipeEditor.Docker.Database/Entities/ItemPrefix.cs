using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Entities;

[EntityTypeConfiguration(typeof(ItemPrefixConfiguration))]
public class ItemPrefix : Asset
{
    public string? Value { get; set; }

    public List<Item> Items { get; set; } = new();
}
