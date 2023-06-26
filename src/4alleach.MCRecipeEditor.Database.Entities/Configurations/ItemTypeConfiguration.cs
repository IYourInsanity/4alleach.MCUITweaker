using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities.Configurations;

public sealed class ItemTypeConfiguration : IEntityTypeConfiguration<ItemType>
{
    public void Configure(EntityTypeBuilder<ItemType> builder)
    {
        builder.Property(p => p.Value)
               .HasMaxLength(10);

        builder.ToTable(nameof(ItemType));
    }
}
