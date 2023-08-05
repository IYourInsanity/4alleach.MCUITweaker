namespace _4alleach.MCRecipeEditor.Docker.Database.Core.Abstractions;

public interface IAssetsContext : IDisposable
{
    TRepository BuildRepository<TRepository, TAsset>()
        where TRepository : IBaseRepository<TAsset>
        where TAsset : Asset;
}
