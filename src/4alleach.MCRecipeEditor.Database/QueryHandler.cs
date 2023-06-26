using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace _4alleach.MCRecipeEditor.Database;

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

    public IEnumerable<object>? SelectAll()
    {
        return Set.ToList();
    }

    public async Task<IEnumerable<object>?> SelectAllAsync(CancellationToken token)
    {
        return await Set.ToListAsync(token);
    }

    public void Insert(object entity)
    {
        var casted = Cast(entity);
        TrackEntity(casted);
        Set.Add(casted);
        context.SaveChanges();
    }

    public void Insert(IEnumerable<object> entities)
    {
        var casted = Cast(entities);
        TrackEntities(casted);
        Set.AddRange(casted);
        context.SaveChanges();
    }

    public async Task InsertAsync(object entity, CancellationToken token)
    {
        var casted = Cast(entity);
        TrackEntity(casted);
        await Set.AddAsync(casted, token);
        await context.SaveChangesAsync(token);
    }

    public async Task InsertAsync(IEnumerable<object> entities, CancellationToken token)
    {
        var casted = Cast(entities);
        TrackEntities(casted);
        await Set.AddRangeAsync(casted, token);
        await context.SaveChangesAsync(token);
    }

    public void Update(object entity)
    {
        var casted = Cast(entity);
        Set.Update(casted);
        context.SaveChanges();
    }

    public void Update(IEnumerable<object> entities)
    {
        var casted = Cast(entities);
        Set.UpdateRange(casted);
        context.SaveChanges();
    }

    public async Task UpdateAsync(object entity, CancellationToken token)
    {
        var casted = Cast(entity);
        Set.Update(casted);
        await context.SaveChangesAsync(token);
    }

    public async Task UpdateAsync(IEnumerable<object> entities, CancellationToken token)
    {
        var casted = Cast(entities);
        Set.UpdateRange(casted);
        await context.SaveChangesAsync(token);
    }

    public void Delete(object entity)
    {
        var casted = Cast(entity);
        Set.Remove(casted);
        context.SaveChanges();
    }

    public void Delete(IEnumerable<object> entities)
    {
        var casted = Cast(entities);
        Set.RemoveRange(casted);
        context.SaveChanges();
    }

    public async Task DeleteAsync(object entity, CancellationToken token)
    {
        var casted = Cast(entity);
        Set.Remove(casted);
        await context.SaveChangesAsync(token);
    }

    public async Task DeleteAsync(IEnumerable<object> entities, CancellationToken token)
    {
        var casted = Cast(entities);
        Set.RemoveRange(casted);
        await context.SaveChangesAsync(token);
    }

    #endregion

    private void TrackEntities(IEnumerable<object> entities)
    {
        foreach (var entity in entities)
        {
            TrackEntity(entity);
        }
    }

    private void TrackEntity(object entity)
    {
        context.ChangeTracker.TrackGraph(entity, node =>
        {
            node.Entry.State = node.Entry.IsKeySet == false ?
                                EntityState.Added :
                                EntityState.Unchanged;
        });
    }

    private static TEntity Cast(object source)
    {
        return (TEntity)source;
    }

    private static IEnumerable<TEntity> Cast(IEnumerable<object> source)
    {
        return source.OfType<TEntity>();
    }
        
}
