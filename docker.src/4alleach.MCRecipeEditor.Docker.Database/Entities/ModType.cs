using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Entities;

[EntityTypeConfiguration(typeof(ModTypeConfiguration))]
public class ModType : Asset
{
    public string? FullName { get; set; }

    public string? ShortName { get; set; }

    public List<Item> Items { get; set; } = new();
}
