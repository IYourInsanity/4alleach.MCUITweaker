using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;

namespace _4alleach.MCRecipeEditor.Database.Abstractions;

public interface IBaseQueryHandler
{
    #region Select

    IEnumerable<object>? SelectAll();

    Task<IEnumerable<object>?> SelectAllAsync(CancellationToken token);

    #endregion

    #region Insert

    void Insert(object entity);

    void Insert(IEnumerable<object> entities);

    Task InsertAsync(object entity, CancellationToken token);

    Task InsertAsync(IEnumerable<object> entities, CancellationToken token);

    #endregion

    #region Update

    void Update(object entity);

    void Update(IEnumerable<object> entities);

    Task UpdateAsync(object entity, CancellationToken token);

    Task UpdateAsync(IEnumerable<object> entities, CancellationToken token);

    #endregion

    #region Delete

    void Delete(object entity);

    void Delete(IEnumerable<object> entities);

    Task DeleteAsync(object entity, CancellationToken token);

    Task DeleteAsync(IEnumerable<object> entities, CancellationToken token);

    #endregion
}

public interface IQueryHandler<TEntity> : IBaseQueryHandler
    where TEntity : Asset
{

}
