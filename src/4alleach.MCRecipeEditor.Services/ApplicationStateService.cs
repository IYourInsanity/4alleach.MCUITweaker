using _4alleach.MCRecipeEditor.Services.Abstractions;
using _4alleach.MCRecipeEditor.Services.Models;

namespace _4alleach.MCRecipeEditor.Services;

internal sealed class ApplicationStateService : IApplicationStateService
{
    private ApplicationState state;

    private readonly IServiceHub serviceHub;

    public ApplicationStateService(IServiceHub hub)
    {
        serviceHub = hub;
        state = ApplicationState.Idle;
    }

    public void Initialize()
    {
        
    }

    public void Update(ApplicationState state)
    {
        this.state = state;

        OnApplicationStateChanged?.Invoke(state);
    }

    public event ApplicationStateChanged? OnApplicationStateChanged;
}
