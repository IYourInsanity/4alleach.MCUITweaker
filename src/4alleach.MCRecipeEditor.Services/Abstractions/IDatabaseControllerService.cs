using _4alleach.MCRecipeEditor.Models.Abstractions.Database;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IDatabaseControllerService : IService
{
    Task<bool> TestConnection();

    Task<IEnumerable<TModel>?> SelectAll<TModel>()
        where TModel : Asset;

    Task<IEnumerable<TModel>?> SelectTop<TModel>(int count)
        where TModel : Asset;

    Task<IEnumerable<TModel>?> SelectCustom<TModel>(string script)
        where TModel : Asset;

    Task<int> Insert<TModel>(TModel model)
        where TModel : Asset;

    Task<int> Insert<TModel>(IEnumerable<TModel> models)
        where TModel : Asset;

    Task<int> Update<TModel>(TModel model)
        where TModel : Asset;

    Task<int> Update<TModel>(IEnumerable<TModel> models)
        where TModel : Asset;

    Task<int> Delete<TModel>(TModel model)
        where TModel : Asset;

    Task<int> Delete<TModel>(IEnumerable<TModel> models)
        where TModel : Asset;
}
