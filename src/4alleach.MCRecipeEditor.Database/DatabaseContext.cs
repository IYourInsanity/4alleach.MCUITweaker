using _4alleach.MCRecipeEditor.Common.Helpers;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database;

public sealed class DatabaseContext : DbContext, IDbContext
{
    private const string Extension = ".db";
    private const string Asset = "4alleach.Asset";
    private const string Folder = "Assets";

    private readonly static Dictionary<Type, Type> HandlerStorage;

    private readonly string connectionString;

    private string SourceName => $"{Asset}{Extension}";
    private string FolderPath => Path.Combine(FileHelper.RootPath, Folder);
    private string AssetPath => Path.Combine(FolderPath, SourceName);

    static DatabaseContext()
    {
        HandlerStorage = new Dictionary<Type, Type>()
        {
            { typeof(Item), typeof(QueryHandler<Item>) },
            { typeof(ItemPostfix), typeof(QueryHandler<ItemPostfix>) },
            { typeof(ItemPrefix), typeof(QueryHandler<ItemPrefix>) },
            { typeof(ItemType), typeof(QueryHandler<ItemType>) },
            { typeof(ModType), typeof(QueryHandler<ModType>) }
        };
    }

    public DatabaseContext() : base()
    {
        connectionString = new SqliteConnectionStringBuilder()
        {
            DataSource = AssetPath,
            DefaultTimeout = 30,
            Pooling = true,
            Cache = SqliteCacheMode.Default,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();

        FolderHelper.CreateIfNotExist(FolderPath);
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

    public IQueryHandler CreateHandler(Type sourceType)
    {
        if(HandlerStorage.TryGetValue(sourceType, out var handlerType))
        {
            return (IQueryHandler)Activator.CreateInstance(handlerType, this)!;
        }

        throw new NotImplementedException();
    }
}
