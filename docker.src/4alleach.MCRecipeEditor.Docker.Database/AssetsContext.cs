using _4alleach.MCRecipeEditor.Docker.Database;
using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Helper;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Concurrent;

namespace _4alleach.MCRecipeEditor.Database;

public sealed class AssetsContext : DbContext, IAssetsContext
{
    private const string Asset = "4alleach.Asset.db";

    private static ConcurrentDictionary<Type, Func<IQueryHandler>> ContextStorage { get; }

    private static string ConnectionString { get; set; }

    static AssetsContext()
    {
        ContextStorage = new ConcurrentDictionary<Type, Func<IQueryHandler>>();
        ConnectionString = new SqliteConnectionStringBuilder()
        {
            DataSource = Asset,
            DefaultTimeout = 30,
            Pooling = true,
            Cache = SqliteCacheMode.Default,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();
    }

    public AssetsContext() : base()
    {
        ContextStorage.TryAdd(typeof(Item), ExpressionHelper.BuildLambdaWithConstructor<QueryHandler<Item>>(this));
        ContextStorage.TryAdd(typeof(ItemPostfix), ExpressionHelper.BuildLambdaWithConstructor<QueryHandler<ItemPostfix>>(this));
        ContextStorage.TryAdd(typeof(ItemPrefix), ExpressionHelper.BuildLambdaWithConstructor<QueryHandler<ItemPrefix>>(this));
        ContextStorage.TryAdd(typeof(ItemType), ExpressionHelper.BuildLambdaWithConstructor<QueryHandler<ItemType>>(this));
        ContextStorage.TryAdd(typeof(ModType), ExpressionHelper.BuildLambdaWithConstructor<QueryHandler<ModType>>(this));

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

    public IQueryHandler<TAsset> CreateHandler<TAsset>()
        where TAsset : Asset
    {
        if(ContextStorage.TryGetValue(typeof(TAsset), out var expression))
        {
            return (IQueryHandler<TAsset>)expression();
        }

        throw new NotImplementedException();
    }
}
