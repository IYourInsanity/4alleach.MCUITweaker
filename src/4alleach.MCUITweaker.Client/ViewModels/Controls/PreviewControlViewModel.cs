using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls;

public sealed partial class PreviewControlViewModel : ControlViewModel<IExtendedWindowViewModel>
{
    private PreviewControlBusinessModel? businessModel;

    [ObservableProperty]
    private ObservableCollection<RecentProjectInfo> openRecentCollection;

    public bool CollectionIsVisible
    {
        get => OpenRecentCollection.Count > 0;
    }

    public PreviewControlViewModel() : base()
    {
        openRecentCollection = new ObservableCollection<RecentProjectInfo>();
    }

    public override void Initialize()
    {
        base.Initialize();

        var generatorService = window?.GetService<IBusinessModelConstructService>();

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

        window?.ShowControl<MenuControl>();
    }

    [RelayCommand]
    private void LoadProject()
    {
        businessModel?.LoadProject();

        window?.ShowControl<MenuControl>();
    }
}

