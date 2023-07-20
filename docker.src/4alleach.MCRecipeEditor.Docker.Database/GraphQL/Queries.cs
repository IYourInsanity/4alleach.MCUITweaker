using _4alleach.MCRecipeEditor.Docker.Database.Core;
using _4alleach.MCRecipeEditor.Docker.Database.Core.Entities;

namespace _4alleach.MCRecipeEditor.Docker.Database.GraphQL;

public class Queries
{
    public IQueryable<Item> Read([Service] AssetsContext ctx) => ctx.BuildHandler<Item>()!.SelectAllAsQueryable()!;
}
