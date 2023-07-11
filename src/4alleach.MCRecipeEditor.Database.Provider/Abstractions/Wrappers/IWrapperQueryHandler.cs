namespace _4alleach.MCRecipeEditor.Database.Provider.Abstractions.Wrappers;

public interface IWrapperQueryHandler<TSource>
    where TSource : class
{
    #region Select

    IEnumerable<TSource> SelectAll();

    Task<IEnumerable<TSource>> SelectAllAsync(CancellationToken token);

    IEnumerable<TSource> SelectWithCondition(Func<dynamic, bool> predicate);

    Task<IEnumerable<TSource>> SelectWithCondition(Func<dynamic, bool> predicate, CancellationToken token);

    #endregion

    #region Insert

    void Insert(TSource source);

    void Insert(IEnumerable<TSource> source);

    Task InsertAsync(TSource source, CancellationToken token);

    Task InsertAsync(IEnumerable<TSource> source, CancellationToken token);

    #endregion

    #region Update

    void Update(TSource source);

    void Update(IEnumerable<TSource> source);

    Task UpdateAsync(TSource source, CancellationToken token);

    Task UpdateAsync(IEnumerable<TSource> source, CancellationToken token);

    #endregion

    #region Delete

    void Delete(TSource source);

    void Delete(IEnumerable<TSource> source);

    Task DeleteAsync(TSource source, CancellationToken token);

    Task DeleteAsync(IEnumerable<TSource> source, CancellationToken token);

    #endregion
}
