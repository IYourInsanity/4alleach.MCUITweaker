using _4alleach.MCRecipeEditor.Models.Database.Base;

namespace _4alleach.MCRecipeEditor.Database.Provider.Abstractions;

public interface IHandler
{

}

public interface IHandler<TModel> : IHandler
    where TModel : Asset
{
    Task<IEnumerable<TModel>?> SelectAllAsync(CancellationToken token);
}
