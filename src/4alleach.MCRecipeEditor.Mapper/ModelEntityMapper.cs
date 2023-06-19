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

    public async Task<IEnumerable<TInternalModel>?> SelectAll<TInternalModel>() 
        where TInternalModel : ModelAsset
    {
        return (await SelectAllInternal()) as IEnumerable<TInternalModel>;
    }

    private async Task<IEnumerable<TModel>?> SelectAllInternal()
    {
        return (await context.SelectAll<TEntity>())!.ToModel<TModel, TEntity>();
    }

    public async Task<IEnumerable<TInternalModel>?> SelectCustom<TInternalModel>(string script) 
        where TInternalModel : ModelAsset
    {
        return (await SelectCustomInternal(script)) as IEnumerable<TInternalModel>;
    }

    private async Task<IEnumerable<TModel>?> SelectCustomInternal(string script)
    {
        return (await context.SelectCustom<TEntity>(script))!.ToModel<TModel, TEntity>();
    }

    public async Task<IEnumerable<TInternalModel>?> SelectTop<TInternalModel>(int count) 
        where TInternalModel : ModelAsset
    {
        return (await SelectTopInternal(count)) as IEnumerable<TInternalModel>;
    }

    public async Task<IEnumerable<TModel>?> SelectTopInternal(int count) 
    {
        return (await context.SelectTop<TEntity>(count))!.ToModel<TModel, TEntity>();
    }

    #endregion

    #region INSERT

    public Task<int> Insert<TInternalModel>(TInternalModel model) 
        where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Insert(entity);
    }

    public Task<int> Insert<TInternalModel>(IEnumerable<TInternalModel> models) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Insert(entities);
    }

    #endregion

    #region DELETE

    public Task<int> Delete<TInternalModel>(TInternalModel model) where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Delete(entity);
    }

    public Task<int> Delete<TInternalModel>(IEnumerable<TInternalModel> models) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Delete(entities);
    }

    #endregion

    #region UPDATE

    public Task<int> Update<TInternalModel>(TInternalModel model) where TInternalModel : ModelAsset
    {
        var entity = model.ToEntity<TEntity, TInternalModel>()!;

        return context.Update(entity);
    }

    public Task<int> Update<TInternalModel>(IEnumerable<TInternalModel> models) where TInternalModel : ModelAsset
    {
        var entities = models.ToEntity<TEntity, TInternalModel>()!;

        return context.Update(entities);
    }

    #endregion
}
