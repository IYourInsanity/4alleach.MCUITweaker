using _4alleach.MCRecipeEditor.Common.Helpers;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities;
using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database;

internal sealed class DatabaseContext : DbContext, IDbContext
{
    private const string Extension = ".db";
    private const string Asset = "4alleach.Asset";
    private const string Folder = "Assets";

    private readonly Dictionary<Type, Type> handlerStorage;

    private string connectionString;

    private string SourceName => $"{Asset}{Extension}";
    private string FolderPath => Path.Combine(FileHelper.RootPath, Folder);
    private string AssetPath => Path.Combine(FolderPath, SourceName);

    internal DatabaseContext() : base()
    {
        handlerStorage = new Dictionary<Type, Type>()
        {
            { typeof(Item), typeof(QueryHandler<Item>) },
            { typeof(ItemPostfix), typeof(QueryHandler<ItemPostfix>) },
            { typeof(ItemPrefix), typeof(QueryHandler<ItemPrefix>) },
            { typeof(ItemType), typeof(QueryHandler<ItemType>) },
            { typeof(ModType), typeof(QueryHandler<ModType>) },
        };

        connectionString = new SqliteConnectionStringBuilder()
        {
            DataSource = AssetPath,
            DefaultTimeout = 30,
            Pooling = true,
            Cache = SqliteCacheMode.Default,
            Mode = SqliteOpenMode.ReadWriteCreate
        }.ToString();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemPostfix>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemPrefix>().UseTpcMappingStrategy();
        modelBuilder.Entity<ItemType>().UseTpcMappingStrategy();
        modelBuilder.Entity<ModType>().UseTpcMappingStrategy();
    }

    public IBaseQueryHandler CreateHandler(Type sourceType)
    {
        if(handlerStorage.TryGetValue(sourceType, out var handlerType))
        {
            return (IBaseQueryHandler)Activator.CreateInstance(handlerType, this)!;
        }

        throw new NotImplementedException();
    }
}
