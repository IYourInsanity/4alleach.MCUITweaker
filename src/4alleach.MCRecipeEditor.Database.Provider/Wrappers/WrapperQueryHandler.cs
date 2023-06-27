using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions.Wrappers;
using _4alleach.MCRecipeEditor.Database.Provider.Extensions;

namespace _4alleach.MCRecipeEditor.Database.Provider.Wrappers;

internal sealed class WrapperQueryHandler<TSource> : IWrapperQueryHandler<TSource>
    where TSource : class
{
    private readonly IDatabaseProvider provider;
    private readonly IQueryHandler handler;

    internal WrapperQueryHandler(IDatabaseProvider provider, IQueryHandler handler)
    {
        this.provider = provider;
        this.handler = handler;
    }

    public IEnumerable<TSource> SelectAll()
    {
        var entities = handler.SelectAll();

        if (entities == null)
        {
            return Enumerable.Empty<TSource>();
        }

        return provider.Map<TSource>(entities);
    }

    public async Task<IEnumerable<TSource>> SelectAllAsync(CancellationToken token)
    {
        var entities = await handler.SelectAllAsync(token);

        if (entities == null)
        {
            return Enumerable.Empty<TSource>();
        }

        return provider.Map<TSource>(entities);
    }


    #region Insert

    public void Insert(TSource source)
    {
        var entity = Map(source);
        handler.Insert(entity);
    }

    public void Insert(IEnumerable<TSource> source)
    {
        var entities = Map(source);
        handler.Insert(entities);
    }

    public Task InsertAsync(TSource source, CancellationToken token)
    {
        var entity = Map(source);
        return handler.InsertAsync(entity, token);
    }

    public Task InsertAsync(IEnumerable<TSource> source, CancellationToken token)
    {
        var entities = Map(source);
        return handler.InsertAsync(entities, token);
    }

    #endregion

    #region Update

    public void Update(TSource source)
    {
        var entity = Map(source);
        handler.Update(entity);
    }

    public void Update(IEnumerable<TSource> source)
    {
        var entities = Map(source);
        handler.Update(entities);
    }

    public Task UpdateAsync(TSource source, CancellationToken token)
    {
        var entity = Map(source);
        return handler.UpdateAsync(entity, token);
    }

    public Task UpdateAsync(IEnumerable<TSource> source, CancellationToken token)
    {
        var entities = Map(source);
        return handler.UpdateAsync(entities, token);
    }

    #endregion

    #region Delete

    public void Delete(TSource source)
    {
        var entity = Map(source);
        handler.Delete(entity);
    }

    public void Delete(IEnumerable<TSource> source)
    {
        var entities = Map(source);
        handler.Delete(entities);
    }

    public Task DeleteAsync(TSource source, CancellationToken token)
    {
        var entity = Map(source);
        return handler.DeleteAsync(entity, token);
    }

    public Task DeleteAsync(IEnumerable<TSource> source, CancellationToken token)
    {
        var entities = Map(source);
        return handler.DeleteAsync(entities, token);
    }

    #endregion

    private object Map(TSource source)
    {
        return provider.Map(source);
    }

    private IEnumerable<object> Map(IEnumerable<TSource> source)
    {
        return source.Select(Map);
    }
}
