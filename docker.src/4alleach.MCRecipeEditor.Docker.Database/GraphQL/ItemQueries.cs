using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Repositories;
using _4alleach.MCRecipeEditor.Docker.Database.GraphQL.Abstractions;

namespace _4alleach.MCRecipeEditor.Docker.Database.GraphQL;

[ExtendObjectType(nameof(Queries<ItemRepository, Item>))]
public sealed class ItemQueries : Queries<ItemRepository, Item>
{
    [UseProjection]
    public IQueryable<Item> ReadAll([Service] IAssetsContext ctx) => Repository(ctx).SelectAllAsQueryable()!;

    public IQueryable<Item> ReadSpecific([Service] IAssetsContext ctx) => Repository(ctx).SelectAllAsQueryable()!;

    [UseProjection]
    public IQueryable<Item> ReadWhereNameIsNotNull([Service] IAssetsContext ctx) => Repository(ctx).SelectAllAsQueryable()!;
}
