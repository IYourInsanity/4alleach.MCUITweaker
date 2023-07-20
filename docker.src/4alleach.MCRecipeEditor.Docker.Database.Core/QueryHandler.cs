using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core;

internal sealed class QueryHandler<TEntity> : IQueryHandler<TEntity>
    where TEntity : Asset
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private DbContext context;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private DbSet<TEntity> Set => context.Set<TEntity>();

    #region Implementation of IDatabaseContext<TEntity>

    public TQueryHandler Build<TQueryHandler>(DbContext context)
        where TQueryHandler : IQueryHandler
    {
        //TODO Rework it
        this.context = context;

        if(this is TQueryHandler handler)
        {
            return handler;
        }

        throw new NotImplementedException();
    }

    public IQueryable<TEntity>? SelectAllAsQueryable()
    {
        return Set;
    }

    public async Task<IEnumerable<TEntity>?> SelectAllAsync(CancellationToken token)
    {
        return await Set.ToListAsync(token);
    }

    public async Task<IEnumerable<TEntity>?> SelectWithConditionAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token)
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
