using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;
using _4alleach.MCRecipeEditor.Docker.Database.GraphQL.Abstractions;

namespace _4alleach.MCRecipeEditor.Docker.Database.GraphQL;

[ExtendObjectType(nameof(Queries<ItemTypeRepository, ItemType>))]
public sealed class ItemTypeQueries : Queries<ItemTypeRepository, ItemType>
{
    [UseProjection]
    public IQueryable<ItemType> ReadAll([Service] IAssetsContext ctx) => Repository(ctx).SelectAllAsQueryable()!;

    public IQueryable<ItemType> ReadSpecific([Service] IAssetsContext ctx) => Repository(ctx).SelectAllAsQueryable()!;
}
