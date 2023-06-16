using _4alleach.MCRecipeEditor.Client.Abstractions;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.Extensions;
using _4alleach.MCRecipeEditor.Client.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Windows;

public sealed partial class MainWindowViewModel : WindowViewModel, IExtendedFrameworkElementViewModel
{
    private readonly MainWindowBusinessModel mwBModel;

    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private string appStateDescription;

    [ObservableProperty]
    private SolidColorBrush appStateColor;

    public MainWindowViewModel(Grid container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
    {
        mwBModel = new MainWindowBusinessModel();

        title = "Minecraft Recipe Editor";
        appStateDescription = "Welcome";
        appStateColor = new SolidColorBrush(Colors.Transparent);
    }

    public override void Initialize()
    {
        provider.RegisterProviderModule<IApplicationStateProvider, ApplicationStateProvider>();
        provider.RegisterProviderModule<IModalWindowProvider, ModalWindowProvider>();

        provider.GetProviderModule<IApplicationStateProvider>()!.OnApplicationStateChanged += OnApplicationStateChanged;

        provider.Register<PreviewControl>();
        provider.Register<MenuControl>();

        provider.Show<PreviewControl>();

        provider.UpdateAppState(ApplicationState.Initialize, "Initialize App");

        mwBModel.Initialize();

        provider.UpdateAppState(ApplicationState.Ready);
    }

    internal TService? GetService<TService>()
        where TService : class, IService
    {
        return mwBModel.GetService<TService>();
    }

    private void OnApplicationStateChanged(SolidColorBrush color, string description)
    {
        AppStateColor = color;
        AppStateDescription = description;
    }
}
