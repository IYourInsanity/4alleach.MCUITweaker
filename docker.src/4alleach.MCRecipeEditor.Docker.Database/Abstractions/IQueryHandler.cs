namespace _4alleach.MCRecipeEditor.Docker.Database.Abstractions;

public interface IQueryHandler<TEntity>
    where TEntity : Asset
{
    #region Select

    Task<IEnumerable<TEntity>?> SelectAllAsync(CancellationToken token);

    Task<IEnumerable<TEntity>?> SelectWithConditionAsync(Func<TEntity, bool> predicate, CancellationToken token);

    #endregion

    #region Insert

    Task InsertAsync(TEntity entity, CancellationToken token);

    Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken token);

    #endregion

    #region Update

    Task UpdateAsync(TEntity entity, CancellationToken token);

    Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken token);

    #endregion

    #region Delete

    Task DeleteAsync(TEntity entity, CancellationToken token);

    Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken token);

    #endregion
}
