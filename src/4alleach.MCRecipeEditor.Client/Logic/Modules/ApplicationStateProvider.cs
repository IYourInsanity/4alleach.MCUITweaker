using _4alleach.MCRecipeEditor.Client.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Common.Helpers;
using _4alleach.MCRecipeEditor.Models.Services;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.Logic.Modules;

internal sealed class ApplicationStateProvider : IApplicationStateProvider
{
    private ApplicationState state;

    private CancellationTokenSource cts;

    public ApplicationState State => state;

    public ApplicationStateProvider()
    {
        cts = new CancellationTokenSource();
    }

    public void Initialize(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
    {
        
    }

    public void Update(ApplicationState state, string description)
    {
        if(state == ApplicationState.Ready)
        {
            TaskHelper.RunWithDelay(() =>
            {
                OnApplicationStateChanged?.Invoke(GetColor(ApplicationState.Idle), string.Empty);
            }, TimeSpan.FromSeconds(1), cts.Token);
        }
        else if(this.state == ApplicationState.Ready)
        {
            cts.Cancel();
            cts.Dispose();

            cts = new CancellationTokenSource();
        }

        this.state = state;
        OnApplicationStateChanged?.Invoke(GetColor(state), description);
    }

    private static SolidColorBrush GetColor(ApplicationState state)
    {
        return state switch
        {
            ApplicationState.Idle => Constants.Colors.Idle,
            ApplicationState.Initialize or ApplicationState.Execute => Constants.Colors.Execute,
            ApplicationState.Warning => Constants.Colors.Warning,
            ApplicationState.Error => Constants.Colors.Error,
            ApplicationState.Ready => Constants.Colors.Ready,
            ApplicationState.Rainbow => Constants.Colors.Rainbow,
            _ => new SolidColorBrush(Colors.Transparent)
        };
    }

    public event ApplicationStateChanged? OnApplicationStateChanged;
}
