using _4alleach.MCRecipeEditor.Database.Provider;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
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

    public IDatabaseProvider CreateProvider()
    {
        return new DatabaseProvider();
    }
}
