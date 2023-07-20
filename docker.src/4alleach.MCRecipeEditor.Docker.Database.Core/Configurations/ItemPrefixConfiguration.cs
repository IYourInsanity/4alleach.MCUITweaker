using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;

public sealed class ItemPrefixConfiguration : IEntityTypeConfiguration<ItemPrefix>
{
    public void Configure(EntityTypeBuilder<ItemPrefix> builder)
    {
        builder.Property(p => p.Value)
               .HasMaxLength(10);

        builder.ToTable(nameof(ItemPrefix));
    }
}
