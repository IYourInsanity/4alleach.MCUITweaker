using _4alleach.MCRecipeEditor.Models.Abstractions.Database;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IDatabaseControllerService : IService
{
    Task<bool> TestConnection();

    Task<IEnumerable<TModel>?> SelectAll<TModel>(CancellationToken token)
        where TModel : Asset;

    Task<IEnumerable<TModel>?> SelectTop<TModel>(int count, CancellationToken token)
        where TModel : Asset;

    Task<IEnumerable<TModel>?> SelectCustom<TModel>(string script, CancellationToken token)
        where TModel : Asset;

    Task<int> Insert<TModel>(TModel model, CancellationToken token)
        where TModel : Asset;

    Task<int> Insert<TModel>(IEnumerable<TModel> models, CancellationToken token)
        where TModel : Asset;

    Task<int> Update<TModel>(TModel model, CancellationToken token)
        where TModel : Asset;

    Task<int> Update<TModel>(IEnumerable<TModel> models, CancellationToken token)
        where TModel : Asset;

    Task<int> Delete<TModel>(TModel model, CancellationToken token)
        where TModel : Asset;

    Task<int> Delete<TModel>(IEnumerable<TModel> models, CancellationToken token)
        where TModel : Asset;
}
