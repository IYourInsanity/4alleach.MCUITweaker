using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using _4alleach.MCRecipeEditor.Client.Extensions;
using _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls.Modals;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Control;

public sealed partial class PreviewControlViewModel : ControlViewModel
{
    private readonly PreviewControlBusinessModel businessModel;

    [ObservableProperty]
    private ObservableCollection<RecentProjectInfo> openRecentCollection;

    public bool CollectionIsVisible
    {
        get => OpenRecentCollection.Count > 0;
    }

    public PreviewControlViewModel(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(provider)
    {
        openRecentCollection = new ObservableCollection<RecentProjectInfo>();
        businessModel = new PreviewControlBusinessModel();
    }

    public override void Initialize()
    {
        base.Initialize();

        OpenRecentCollection.Add(new RecentProjectInfo("Test1", "Test Path"));
        OpenRecentCollection.Add(new RecentProjectInfo("Test2", "Test Path"));

        OnPropertyChanged(nameof(CollectionIsVisible));
    }

    [RelayCommand]
    private void NewProject()
    {
        businessModel?.NewProject();

        root?.Provider.Show<MenuControl>();
    }

    [RelayCommand]
    private async Task LoadProject()
    {
        //businessModel?.LoadProject();

        //root?.Provider?.Show<MenuControl>();

        var result = await root!.Provider.ShowModal<TestModalWindow, TestModalResult>("Test");
    }
}

