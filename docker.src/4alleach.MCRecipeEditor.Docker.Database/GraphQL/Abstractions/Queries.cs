using _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

namespace _4alleach.MCRecipeEditor.Docker.Database.GraphQL.Abstractions;

public abstract class Queries : IQueries {}

public abstract class Queries<TRepository, TEntity> : Queries
    where TRepository: IBaseRepository<TEntity>
    where TEntity : Asset
{
    protected TRepository Repository(IAssetsContext ctx) => ctx.BuildRepository<TRepository, TEntity>();

}
