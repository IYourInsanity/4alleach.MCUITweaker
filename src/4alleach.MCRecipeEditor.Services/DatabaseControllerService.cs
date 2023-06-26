using _4alleach.MCRecipeEditor.Database;
using _4alleach.MCRecipeEditor.Database.Abstractions;
using _4alleach.MCRecipeEditor.Mapper.Abstractions;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;
internal sealed class DatabaseControllerService : IDatabaseControllerService
{
    private readonly IServiceHub serviceHub;

    public DatabaseControllerService(IServiceHub serviceHub) 
    {
        this.serviceHub = serviceHub;
    }

    public void Initialize() 
    {

    }

    public void CreateProvider(Action<IDbProvider> action)
    {
        using(var provider = serviceHub.Get<IAutoMapperService>()!.CreateProvider())
        {
            action(provider);
        }
    }
}
