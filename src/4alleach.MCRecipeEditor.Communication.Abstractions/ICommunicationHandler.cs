namespace _4alleach.MCRecipeEditor.Communication.Abstractions;

public interface ICommunicationHandler : IDisposable
{

}

public interface ICommunicationHandler<TModel> : ICommunicationHandler
    where TModel : class
{
    #region Select

    Task<IEnumerable<TModel>?> SelectAllAsync(CancellationToken token);

    Task<IEnumerable<TModel>?> SelectWithConditionAsync(string condition, CancellationToken token);

    #endregion

    #region Insert

    Task InsertAsync(TModel entity, CancellationToken token);

    Task InsertAsync(IEnumerable<TModel> entities, CancellationToken token);

    #endregion

    #region Update

    Task UpdateAsync(TModel entity, CancellationToken token);

    Task UpdateAsync(IEnumerable<TModel> entities, CancellationToken token);

    #endregion

    #region Delete

    Task DeleteAsync(TModel entity, CancellationToken token);

    Task DeleteAsync(IEnumerable<TModel> entities, CancellationToken token);

    #endregion
}
