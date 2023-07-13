namespace _4alleach.MCRecipeEditor.Docker.Database.Abstractions;

public interface IAssetsContext : IDisposable
{
    IQueryHandler<TAsset> CreateHandler<TAsset>()
        where TAsset : Asset;
}
