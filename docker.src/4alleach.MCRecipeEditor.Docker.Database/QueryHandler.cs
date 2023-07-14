using _4alleach.MCRecipeEditor.Docker.Database.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace _4alleach.MCRecipeEditor.Docker.Database;

internal sealed class QueryHandler<TEntity> : IQueryHandler<TEntity>
    where TEntity : Asset
{
    private readonly DbContext context;

    private DbSet<TEntity> Set => context.Set<TEntity>();

    public QueryHandler(DbContext context)
    {
        this.context = context;
    }

    #region Implementation of IDatabaseContext<TEntity>

    public async Task<IEnumerable<TEntity>?> SelectAllAsync(CancellationToken token)
    {
        return await Set.ToListAsync(token);
    }

    public async Task<IEnumerable<TEntity>?> SelectWithConditionAsync(Func<TEntity, bool> predicate, CancellationToken token)
    {
        return await Set.Where(predicate).ToDynamicListAsync<TEntity>(token);
    }

    public async Task InsertAsync(TEntity entity, CancellationToken token)
    {
        await Set.AddAsync(entity, token);
        await context.SaveChangesAsync(token);
    }

    public async Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        await context.AddRangeAsync(entities, token);
        await context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken token)
    {
        Set.Update(entity);
        await context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        Set.UpdateRange(entities);
        await context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken token)
    {
        Set.Remove(entity);
        await context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        Set.RemoveRange(entities);
        await context.SaveChangesAsync(token);
    }

    #endregion        
}
