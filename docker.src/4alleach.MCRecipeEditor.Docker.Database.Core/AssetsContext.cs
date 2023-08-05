using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core;

public sealed class AssetsContext : DbContext, IAssetsContext
{
    private const string ConnectionString = "Data Source=4alleach.Asset.db; Mode=ReadWriteCreate; Cache=Default; Default Timeout=30; Pooling=True";

    private readonly IRepositoryCollection _repositories;

    public AssetsContext(IRepositoryCollection repositories) : base()
    {
        _repositories = repositories;

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

        modelBuilder.Entity<Account>().UseTpcMappingStrategy();
    }

    public TRepository BuildRepository<TRepository, TAsset>()
        where TRepository: IBaseRepository<TAsset>
        where TAsset : Asset
    {
        return _repositories.Build<TRepository, TAsset>(this);
    }
}
