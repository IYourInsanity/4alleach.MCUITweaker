using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database.Entities.Configurations;

public sealed class ItemPostfixConfiguration : IEntityTypeConfiguration<ItemPostfix>
{
    public void Configure(EntityTypeBuilder<ItemPostfix> builder)
    {
        builder.Property(p => p.Value)
               .HasMaxLength(10);

        builder.ToTable(nameof(ItemPostfix));
    }
}

