using _4alleach.MCRecipeEditor.Communication.Abstractions;
using _4alleach.MCRecipeEditor.Communication.Models;
using _4alleach.MCRecipeEditor.Services.Abstractions;

namespace _4alleach.MCRecipeEditor.Services;
internal sealed class CommunicationService : ICommunicationService
{
    private readonly IServiceHub serviceHub;
    private readonly IHttpManager manager;

    public CommunicationService(IServiceHub serviceHub, IHttpManager manager) 
    {
        this.serviceHub = serviceHub;
        this.manager = manager;
    }

    public void Initialize() 
    {

    }

    public IHttpProvider Use(ProviderType type)
    {
        return manager.Use(type);
    }
}
