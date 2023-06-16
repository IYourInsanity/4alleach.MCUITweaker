using _4alleach.MCRecipeEditor.Client.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Models.Services;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.Abstractions;

internal delegate void ApplicationStateChanged(SolidColorBrush color, string description);

internal interface IApplicationStateProvider : IProviderModule
{
    ApplicationState State { get; }

    void Update(ApplicationState state, string description);

    event ApplicationStateChanged OnApplicationStateChanged;
}
