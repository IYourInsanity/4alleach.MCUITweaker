using ModelAsset = _4alleach.MCRecipeEditor.Models.Abstractions.Database.Asset;

namespace _4alleach.MCRecipeEditor.Mapper.Abstractions;

public interface IModelEntityMapper
{
    Task<IEnumerable<TInternalModel>?> SelectAll<TInternalModel>()
        where TInternalModel : ModelAsset;

    Task<IEnumerable<TInternalModel>?> SelectTop<TInternalModel>(int count)
        where TInternalModel : ModelAsset;

    Task<IEnumerable<TInternalModel>?> SelectCustom<TInternalModel>(string script)
        where TInternalModel : ModelAsset;

    Task<int> Insert<TInternalModel>(TInternalModel model)
        where TInternalModel : ModelAsset;

    Task<int> Insert<TInternalModel>(IEnumerable<TInternalModel> models)
        where TInternalModel : ModelAsset;

    Task<int> Update<TInternalModel>(TInternalModel model)
        where TInternalModel : ModelAsset;

    Task<int> Update<TInternalModel>(IEnumerable<TInternalModel> models)
        where TInternalModel : ModelAsset;

    Task<int> Delete<TInternalModel>(TInternalModel model)
        where TInternalModel : ModelAsset;

    Task<int> Delete<TInternalModel>(IEnumerable<TInternalModel> models)
        where TInternalModel : ModelAsset;
}
