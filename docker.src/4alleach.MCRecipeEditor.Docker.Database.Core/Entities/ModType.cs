using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

[EntityTypeConfiguration(typeof(ModTypeConfiguration))]
public class ModType : Asset
{
    public string? FullName { get; set; }

    public string? ShortName { get; set; }

    public List<Item> Items { get; set; } = new();
}
