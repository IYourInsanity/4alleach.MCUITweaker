using _4alleach.MCRecipeEditor.Client.Abstractions;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.Extensions;
using _4alleach.MCRecipeEditor.Client.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls.Modals;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Client.Views.Controls.ContextMenu;
using _4alleach.MCRecipeEditor.Models.Services;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Window;

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
        provider.RegisterProviderModule<IContextMenuProvider, ContextMenuProvider>();

        provider.GetProviderModule<IApplicationStateProvider>()!.OnApplicationStateChanged += OnApplicationStateChanged;

        var contextMenuProvider = provider.GetProviderModule<IContextMenuProvider>()!;

        contextMenuProvider.Register<StandardContextMenu>("TopContextMenu", InitializeTopContextMenu);
        contextMenuProvider.Register<StandardContextMenu>("BottomContextMenu", InitializeBottomContextMenu);

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

    #region Context Menu

    [RelayCommand]
    private async void TestContextAction()
    {
        _ = await provider.ShowModal<TestModalWindow, TestModalResult>("Test");
    }

    private void InitializeTopContextMenu(IContextMenuElement contextMenu)
    {
        var standardContextMenuButtonStyle = Constants.Styles.StandardContextMenuButtonStyle;
        var extendedSeparatorStyle = Constants.Styles.ExtendedSeparatorStyle;

        contextMenu.Add<Button>("Test Context Menu 1", TestContextActionCommand, standardContextMenuButtonStyle);
        contextMenu.Add<Separator>(extendedSeparatorStyle);
        contextMenu.Add<Button>("Test Context Menu 2", TestContextActionCommand, standardContextMenuButtonStyle);
        contextMenu.Add<Button>("Test Context Menu 3", TestContextActionCommand, standardContextMenuButtonStyle);
    }

    private void InitializeBottomContextMenu(IContextMenuElement contextMenu)
    {
        contextMenu.Add<Button>("Test Context Bottom Menu", TestContextActionCommand, Constants.Styles.StandardContextMenuButtonStyle);
    }

    #endregion
}
