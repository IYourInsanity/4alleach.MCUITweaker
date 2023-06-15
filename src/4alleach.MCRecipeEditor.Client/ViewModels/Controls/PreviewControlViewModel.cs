using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using _4alleach.MCRecipeEditor.Client.ViewModels.Windows;
using _4alleach.MCRecipeEditor.Services.Abstractions;
using _4alleach.MCRecipeEditor.Client.Extensions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls.Modals;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls;

public sealed partial class PreviewControlViewModel : ControlViewModel
{
    private PreviewControlBusinessModel? businessModel;

    [ObservableProperty]
    private ObservableCollection<RecentProjectInfo> openRecentCollection;

    public bool CollectionIsVisible
    {
        get => OpenRecentCollection.Count > 0;
    }

    public PreviewControlViewModel(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(provider)
    {
        openRecentCollection = new ObservableCollection<RecentProjectInfo>();
    }

    public override void Initialize()
    {
        base.Initialize();

        var generatorService = root?.Provider.GetService<IBusinessModelConstructService>();

        if(generatorService == null)
        {
            return;
        }

        generatorService.GenerateBusinessModelByName(ControlName);

        businessModel = generatorService.GetModel<PreviewControlBusinessModel>();

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

