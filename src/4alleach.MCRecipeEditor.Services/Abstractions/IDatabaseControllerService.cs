using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IDatabaseControllerService : IService
{
    void CreateProvider(Action<IDbProvider> action);
}
