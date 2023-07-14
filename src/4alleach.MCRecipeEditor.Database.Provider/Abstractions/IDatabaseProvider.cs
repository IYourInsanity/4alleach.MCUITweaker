using _4alleach.MCRecipeEditor.Models.Database.Base;

namespace _4alleach.MCRecipeEditor.Database.Provider.Abstractions;

public interface IDatabaseProvider : IDisposable
{
    IHandler<TModel> UseHandler<TModel>()
        where TModel : Asset;   
}
