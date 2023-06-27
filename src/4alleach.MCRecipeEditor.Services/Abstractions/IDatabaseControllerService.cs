using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public interface IDatabaseControllerService : IService
{
    IDatabaseProvider CreateProvider();
}
