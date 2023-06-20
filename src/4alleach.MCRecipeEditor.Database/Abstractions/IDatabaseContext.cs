using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;

namespace _4alleach.MCRecipeEditor.Database.Abstractions;

public interface IDatabaseContext
{
    void Initialize();

    Task<bool> TestConnection();

    Task<IEnumerable<TEntity>?> SelectAll<TEntity>(CancellationToken token)
        where TEntity : Asset;

    Task<IEnumerable<TEntity>?> SelectTop<TEntity>(int count, CancellationToken token)
        where TEntity : Asset;

    Task<IEnumerable<TEntity>?> SelectCustom<TEntity>(string script, CancellationToken token)
        where TEntity : Asset;

    Task<int> Insert<TEntity>(TEntity entity, CancellationToken token)
        where TEntity : Asset;

    Task<int> Insert<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
        where TEntity : Asset;

    Task<int> Update<TEntity>(TEntity entity, CancellationToken token)
        where TEntity : Asset;

    Task<int> Update<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
        where TEntity : Asset;

    Task<int> Delete<TEntity>(TEntity entity, CancellationToken token)
        where TEntity : Asset;

    Task<int> Delete<TEntity>(IEnumerable<TEntity> entities, CancellationToken token)
        where TEntity : Asset;
}
