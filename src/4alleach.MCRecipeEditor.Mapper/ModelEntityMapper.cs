using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Extensions;

using EntityAsset = _4alleach.MCRecipeEditor.Database.Entities.Abstractions.Asset;
using ModelAsset = _4alleach.MCRecipeEditor.Models.Abstractions.Database.Asset;

namespace _4alleach.MCRecipeEditor.Database.Mappers;
internal sealed class ModelEntityMapper<TModel, TEntity> : IModelEntityMapper
      where TModel : ModelAsset
      where TEntity : EntityAsset
{
    private readonly IDatabaseContext context;

    internal ModelEntityMapper(IDatabaseContext context)
    {
        this.context = context;
    }

    #region SELECT

    public async Task<IEnumerable<TInternalModel>?> SelectAll<TInternalModel>(CancellationToken token) 
        where TInternalModel : ModelAsset
    {
        return (await SelectAllInternal(token)) as IEnumerable<TInternalModel>;
    }

    private async Task<IEnumerable<TModel>?> SelectAllInternal(CancellationToken token)
    {
        return (await context.SelectAll<TEntity>(token))!.ToModel<TModel, TEntity>();
    }

    public async Task<IEnumerable<TInternalModel>?> SelectCustom<TInternalModel>(string script, CancellationToken token) 
        where TInternalModel : ModelAsset
    {
        return (await SelectCustomInternal(script, token)) as IEnumerable<TInternalModel>;
    }

    private async Task<IEnumerable<TModel>?> SelectCustomInternal(string script, CancellationToken token)
    {
        return (await context.SelectCustom<TEntity>(script, token))!.ToModel<TModel, TEntity>();
    }

    public async Task<IEnumerable<TInternalModel>?> SelectTop<TInternalModel>(int count, CancellationToken token) 
        where TInternalModel : ModelAsset
    {
        return (await SelectTopInternal(count, token)) as IEnumerable<TInternalModel>;
    }

    public async Task<IEnumerable<TModel>?> SelectTopInternal(int count, CancellationToken token) 
    {
        return (await context.SelectTop<TEntity>(count, token))!.ToModel<TModel, TEntity>();
    }

    #endregion

    #region INSERT

    public Task<int> Insert<TInternalModel>(TInternalModel model, CancellationToken token) 
        where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Insert(entity, token);
    }

    public Task<int> Insert<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Insert(entities, token);
    }

    #endregion

    #region DELETE

    public Task<int> Delete<TInternalModel>(TInternalModel model, CancellationToken token) where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Delete(entity, token);
    }

    public Task<int> Delete<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Delete(entities, token);
    }

    #endregion

    #region UPDATE

    public Task<int> Update<TInternalModel>(TInternalModel model, CancellationToken token) where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Update(entity, token);
    }

    public Task<int> Update<TInternalModel>(IEnumerable<TInternalModel> models, CancellationToken token) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Update(entities, token);
    }

    #endregion
}
