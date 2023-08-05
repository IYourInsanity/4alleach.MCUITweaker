using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : Asset
{
    private DbContext? _context;

    internal DbContext Context => _context!;

    private DbSet<TEntity> Set => Context.Set<TEntity>();

    #region Implementation of IDatabaseContext<TEntity>

    public TRepository Build<TRepository>(DbContext context) 
        where TRepository : IBaseRepository<TEntity>
    {
        _context = context;

        if (this is TRepository repository)
        {
            return repository;
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
        await Context.SaveChangesAsync(token);
    }

    public async Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        await Context.AddRangeAsync(entities, token);
        await Context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken token)
    {
        Set.Update(entity);
        await Context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        Set.UpdateRange(entities);
        await Context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken token)
    {
        Set.Remove(entity);
        await Context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken token)
    {
        Set.RemoveRange(entities);
        await Context.SaveChangesAsync(token);
    }

    #endregion

}
