using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

public interface IBaseRepository
{
}

public interface IBaseRepository<TEntity> : IBaseRepository
    where TEntity : Asset
{
    TRepository Build<TRepository>(DbContext context)
        where TRepository : IBaseRepository<TEntity>;

    #region Select

IQueryable<TEntity>? SelectAllAsQueryable();

    Task<IEnumerable<TEntity>?> SelectAllAsync(CancellationToken token);

    Task<IEnumerable<TEntity>?> SelectWithConditionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token);

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
