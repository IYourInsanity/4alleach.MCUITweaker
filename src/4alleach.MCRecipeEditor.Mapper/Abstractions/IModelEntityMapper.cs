using ModelAsset = _4alleach.MCRecipeEditor.Models.Abstractions.Database.Asset;

namespace _4alleach.MCRecipeEditor.Mapper.Abstractions;

public interface IModelEntityMapper
{
    Task<IEnumerable<TInternalModel>?> SelectAll<TInternalModel>(CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<IEnumerable<TInternalModel>?> SelectTop<TInternalModel>(int count, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<IEnumerable<TInternalModel>?> SelectCustom<TInternalModel>(string script, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Insert<TInternalModel>(TInternalModel model, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Insert<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Update<TInternalModel>(TInternalModel model, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Update<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Delete<TInternalModel>(TInternalModel model, CancellationToken token)
        where TInternalModel : ModelAsset;

    Task<int> Delete<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token)
        where TInternalModel : ModelAsset;
}
