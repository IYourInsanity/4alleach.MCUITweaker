using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Configurations;

public sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(p => p.Login)
               .HasMaxLength(24);

        builder.Property(p => p.Password)
               .HasMaxLength(24);

        builder.Property(p => p.AccessLevel);

        builder.ToTable(nameof(Account));
    }
}
