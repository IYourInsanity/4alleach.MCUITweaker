using _4alleach.MCRecipeEditor.Database.Provider;
using _4alleach.MCRecipeEditor.Database.Provider.Abstractions;
using _4alleach.MCRecipeEditor.Database.Provider.Extensions;
using _4alleach.MCRecipeEditor.Models.Database;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;
internal sealed class DatabaseControllerService : IDatabaseControllerService
{
    private readonly IServiceHub serviceHub;

    private bool isPreloaded;

    public DatabaseControllerService(IServiceHub serviceHub) 
    {
        this.serviceHub = serviceHub;
    }

    public void Initialize() 
    {

    }

    public void PreloadDatabase()
    {
        if(isPreloaded)
        {
            return;
        }

        var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

        Task.Run(() =>
        {
            using (var request = RequestProvider())
            {
                request.Prepare<Item>();
                request.Prepare<ItemType>();
                request.Prepare<ModType>();
            }

            isPreloaded = true;
        }, cts.Token);
    }

    public IDatabaseProvider RequestProvider()
    {
        return new DatabaseProvider();
    }
}
