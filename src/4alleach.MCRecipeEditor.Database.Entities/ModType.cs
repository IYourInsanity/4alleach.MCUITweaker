using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities;

[EntityTypeConfiguration(typeof(ModTypeConfiguration))]
public class ModType : Asset
{
    public string? FullName { get; set; }

    public string? ShortName { get; set; }

    public List<Item> Items { get; set; } = new();
}
