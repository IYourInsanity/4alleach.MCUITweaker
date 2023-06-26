using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities.Configurations;

public sealed class ItemPrefixConfiguration : IEntityTypeConfiguration<ItemPrefix>
{
    public void Configure(EntityTypeBuilder<ItemPrefix> builder)
    {
        builder.Property(p => p.Value)
               .HasMaxLength(10);

        builder.ToTable(nameof(ItemPrefix));
    }
}
