using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core;

public sealed class AssetsContext : DbContext, IAssetsContext
{
    private const string ConnectionString = "Data Source=4alleach.Asset.db; Mode=ReadWriteCreate; Cache=Default; Default Timeout=30; Pooling=True";

    private readonly IQueryHandlerRepository repository;

    public AssetsContext(IQueryHandlerRepository repository) : base()
    {
        this.repository = repository;

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(ConnectionString)
                      .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemPostfix>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemPrefix>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemType>().UseTpcMappingStrategy();
        modelBuilder.Entity<ModType>().UseTpcMappingStrategy();
    }

    public IQueryHandler<TAsset> BuildHandler<TAsset>()
        where TAsset : Asset
    {
        return repository.Build<TAsset>(this);
    }
}
