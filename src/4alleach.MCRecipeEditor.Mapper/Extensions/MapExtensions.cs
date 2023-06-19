using _4alleach.MCRecipeEditor.Database.Entities.Attributes;
using System.Reflection;

using EntityAsset = _4alleach.MCRecipeEditor.Database.Entities.Abstractions.Asset;
using ModelAsset = _4alleach.MCRecipeEditor.Models.Abstractions.Database.Asset;

namespace _4alleach.MCRecipeEditor.Mapper.Extensions;

internal static class MapExtensions
{
    internal static IEnumerable<TModel> ToModel<TModel, TEntity>(this IEnumerable<TEntity> entities)
        where TModel : ModelAsset
        where TEntity : EntityAsset
    {
        var models = new List<TModel>();

        if (entities == null)
        {
            throw new NotImplementedException();
        }

        foreach (var entity in entities)
        {
            var model = ToModel<TModel, TEntity>(entity);

            if (model == null)
            {
                throw new NotImplementedException();
            }

            models.Add(model);
        }

        return models;
    }

    internal static IEnumerable<TEntity> ToEntity<TEntity, TModel>(this IEnumerable<TModel> models)
        where TEntity : EntityAsset
        where TModel : ModelAsset
    {
        var entities = new List<TEntity>();

        if (models == null)
        {
            throw new NotImplementedException();
        }

        foreach (var model in models)
        {
            var entity = ToEntity<TEntity, TModel>(model);

            if (entity == null)
            {
                throw new NotImplementedException();
            }

            entities.Add(entity);
        }

        return entities;
    }

    internal static TEntity? ToEntity<TEntity, TModel>(this TModel model)
        where TModel : ModelAsset
        where TEntity : EntityAsset
    {
        var instance = Activator.CreateInstance<TEntity>();

        var entityType = typeof(TEntity);
        var entityProperties = entityType.GetProperties().ToArray();
        var entityPropertiesLength = entityProperties.Length;

        var modelType = typeof(TModel);
        var modelProperties = modelType.GetProperties().ToArray();
        var modelPropertiesLength = modelProperties.Length;

        if (entityPropertiesLength != modelPropertiesLength)
        {
            return default;
        }

        for (var i = 0; i < entityProperties.Length; i++)
        {
            var entityProperty = entityProperties[i];
            var modelProperty = modelProperties[i];

            var modelPropertyValue = modelProperty.GetValue(model);

            entityProperty.SetValue(instance, modelPropertyValue);
        }

        return instance;
    }

    internal static TModel? ToModel<TModel, TEntity>(this TEntity entity)
        where TModel : ModelAsset
        where TEntity : EntityAsset
    {
        var instance = Activator.CreateInstance<TModel>();

        var entityType = typeof(TEntity);
        var entityProperties = entityType.GetProperties().ToArray();
        var entityPropertiesLength = entityProperties.Length;

        var modelType = typeof(TModel);
        var modelProperties = modelType.GetProperties().ToArray();
        var modelPropertiesLength = modelProperties.Length;

        if (entityPropertiesLength != modelPropertiesLength)
        {
            return default;
        }

        for (var i = 0; i < entityProperties.Length; i++)
        {
            var entityProperty = entityProperties[i];
            var modelProperty = modelProperties[i];

            var isForeignKey = entityProperty.GetCustomAttributes<ForeignKeyAttribute>(false).Any();

            if (isForeignKey)
            {
                //TODO Implement logic which find ref to element
            }

            var entityPropertyValue = entityProperty.GetValue(entity);

            modelProperty.SetValue(instance, entityPropertyValue);
        }

        return instance;
    }
}
