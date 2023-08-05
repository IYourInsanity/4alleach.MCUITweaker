using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

[EntityTypeConfiguration(typeof(AccountConfiguration))]
public class Account : Asset
{
    public required string Login { get; set; }

    public required string Password { get; set; }

    public required AccessLevel AccessLevel { get; set; }
}

public enum AccessLevel
{
    Read = 0,
    All = 1
}
