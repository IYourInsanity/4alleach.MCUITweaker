using _4alleach.MCRecipeEditor.Database;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using System.Data.SQLite;

namespace _4alleach.MCRecipeEditor.Services;
internal sealed class DatabaseControllerService : IDatabaseControllerService
{
    private readonly IServiceHub serviceHub;

    private IDatabaseContext? context;

    public DatabaseControllerService(IServiceHub serviceHub)
    {
        this.serviceHub = serviceHub;
    }

    public void Initialize()
    {
        context = Entry.CreateContext();
        context.Initialize();
    }

    public Task<bool> TestConnection()
    {
        if (context == null)
        {
            return Task.FromResult(false);
        }

        return context.TestConnection();
    }

    public Task<int> Delete<TEntity>(TEntity entity) where TEntity : Asset
    {
        return context!.Delete(entity);
    }

    public Task<int> Delete<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        return context!.Delete(entities);
    }

    public Task ExecuteAdapter(string script, Action<SQLiteDataAdapter> action)
    {
        return context!.ExecuteAdapter(script, action);
    }

    public Task ExecuteNonQueryAsync(string script)
    {
        return context!.ExecuteNonQueryAsync(script);
    }

    public Task ExecuteNonQueryAsync(string script, Action<SQLiteCommand> action)
    {
        return context!.ExecuteNonQueryAsync(script, action);
    }

    public Task ExecuteReader<TResult>(string script, Func<SQLiteDataReader, TResult> func)
    {
        return context!.ExecuteReader(script, func);
    }

    public Task<int> Insert<TEntity>(TEntity entity) where TEntity : Asset
    {
        return context!.Insert(entity);
    }

    public Task<int> Insert<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        return context!.Insert(entities);
    }

    public Task<IEnumerable<TEntity>?> SelectAll<TEntity>() where TEntity : Asset
    {
        return context!.SelectAll<TEntity>();
    }

    public Task<IEnumerable<TEntity>?> SelectCustom<TEntity>(string script) where TEntity : Asset
    {
        return context!.SelectCustom<TEntity>(script);
    }

    public Task<IEnumerable<TEntity>?> SelectTop<TEntity>(int count) where TEntity : Asset
    {
        return context!.SelectTop<TEntity>(count);
    }

    public Task<int> Update<TEntity>(TEntity entity) where TEntity : Asset
    {
        return context!.Update<TEntity>(entity);
    }

    public Task<int> Update<TEntity>(IEnumerable<TEntity> entities) where TEntity : Asset
    {
        return context!.Update<TEntity>(entities);
    }
}
