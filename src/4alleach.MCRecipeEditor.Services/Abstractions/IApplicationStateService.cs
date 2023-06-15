using _4alleach.MCRecipeEditor.Services.Models;

namespace _4alleach.MCRecipeEditor.Services.Abstractions;

public delegate void ApplicationStateChanged(ApplicationState state);

public interface IApplicationStateService : IService
{
    void Update(ApplicationState state);

    event ApplicationStateChanged OnApplicationStateChanged;
}
