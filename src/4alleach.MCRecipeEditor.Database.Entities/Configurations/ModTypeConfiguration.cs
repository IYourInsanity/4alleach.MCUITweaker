using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities.Configurations;

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
