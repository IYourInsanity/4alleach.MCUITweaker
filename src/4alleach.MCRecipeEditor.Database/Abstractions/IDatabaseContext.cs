using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using System.Data.SQLite;

namespace _4alleach.MCRecipeEditor.Database.Abstractions;

public interface IDatabaseContext
{
    void Initialize();

    Task<bool> TestConnection();

    Task<IEnumerable<TEntity>?> SelectAll<TEntity>()
        where TEntity : Asset;

    Task<IEnumerable<TEntity>?> SelectTop<TEntity>(int count)
        where TEntity : Asset;

    Task<IEnumerable<TEntity>?> SelectCustom<TEntity>(string script)
        where TEntity : Asset;

    Task<int> Insert<TEntity>(TEntity entity)
        where TEntity : Asset;

    Task<int> Insert<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset;

    Task<int> Update<TEntity>(TEntity entity)
        where TEntity : Asset;

    Task<int> Update<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset;

    Task<int> Delete<TEntity>(TEntity entity)
        where TEntity : Asset;

    Task<int> Delete<TEntity>(IEnumerable<TEntity> entities)
        where TEntity : Asset;
}
