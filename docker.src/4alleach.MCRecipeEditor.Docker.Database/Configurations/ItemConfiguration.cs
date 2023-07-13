using _4alleach.MCRecipeEditor.Docker.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4alleach.MCRecipeEditor.Docker.Database.Configurations;

public sealed class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.Property(p => p.Name)
               .HasMaxLength(50);

        builder.Property(p => p.Description)
               .HasMaxLength(200);

        builder.HasOne(p => p.ItemType)
               .WithMany(p => p.Items)
               .HasForeignKey(p => p.ItemTypeId);

        builder.HasOne(p => p.ModType)
               .WithMany(p => p.Items)
               .HasForeignKey(p => p.ModTypeId);

        builder.HasOne(p => p.ItemPrefix)
               .WithMany(p => p.Items)
               .HasForeignKey(p => p.ItemPrefixId);

        builder.HasOne(p => p.ItemPostfix)
               .WithMany(p => p.Items)
               .HasForeignKey(p => p.ItemPostfixId);

        builder.ToTable(nameof(Item));
    }
}
