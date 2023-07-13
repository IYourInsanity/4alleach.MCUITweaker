using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using _4alleach.MCRecipeEditor.Docker.Database.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.Configurations;

public sealed class ModTypeConfiguration : IEntityTypeConfiguration<ModType>
{
    public void Configure(EntityTypeBuilder<ModType> builder)
    {
        builder.Property(p => p.FullName)
               .HasMaxLength(50);

        builder.Property(p => p.ShortName)
               .HasMaxLength(20);

        builder.ToTable(nameof(ModType));
    }
}
