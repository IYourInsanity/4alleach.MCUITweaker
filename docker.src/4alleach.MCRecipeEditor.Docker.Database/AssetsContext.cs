using _4alleach.MCRecipeEditor.Docker.Database;
using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Database;

public sealed class AssetsContext : DbContext, IAssetsContext
{
    private const string Asset = "4alleach.Asset.db";

    private readonly static ConcurrentDictionary<Type, Type> HandlerStorage;

    private readonly string connectionString;

    static AssetsContext()
    {
        HandlerStorage = new ConcurrentDictionary<Type, Type>();

        HandlerStorage.TryAdd(typeof(Item), typeof(QueryHandler<Item>));
        HandlerStorage.TryAdd(typeof(ItemPostfix), typeof(QueryHandler<ItemPostfix>));
        HandlerStorage.TryAdd(typeof(ItemPrefix), typeof(QueryHandler<ItemPrefix>));
        HandlerStorage.TryAdd(typeof(ItemType), typeof(QueryHandler<ItemType>));
        HandlerStorage.TryAdd(typeof(ModType), typeof(QueryHandler<ModType>));
    }

    public AssetsContext() : base()
    {
        connectionString = new SqliteConnectionStringBuilder()
        {
            DataSource = Asset,
            DefaultTimeout = 30,
            Pooling = true,
            Cache = SqliteCacheMode.Default,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();

        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString)
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

    public IQueryHandler<TAsset> CreateHandler<TAsset>()
        where TAsset : Asset
    {
        if(HandlerStorage.TryGetValue(typeof(TAsset), out var handlerType))
        {
            return (IQueryHandler<TAsset>)Activator.CreateInstance(handlerType, this)!;
        }

        throw new NotImplementedException();
    }
}
