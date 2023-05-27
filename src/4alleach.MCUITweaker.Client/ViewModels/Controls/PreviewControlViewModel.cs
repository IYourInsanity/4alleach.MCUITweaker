using _4alleach.MCRecipeEditor.Client.Abstractions.Services;
using _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;
using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using _4alleach.MCRecipeEditor.Client.Views.Controls;
using _4alleach.MCRecipeEditor.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls;

public sealed partial class PreviewControlViewModel : ControlViewModel
{
    private PreviewControlBusinessModel? previewControlBM;
    private IExtendedWindowViewModel? windowViewModel;

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
        if(control == null)
        {
            return;
        }

        var root = control.Picker.GetParent<ExtendedWindow>();

        if(root == null)
        {
            return;
        }

        windowViewModel = root.Picker.GetViewModel<IExtendedWindowViewModel>();

        if(windowViewModel == null)
        {
            return;
        }

        var generatorService = windowViewModel.GetService<IBusinessModelConstructService>();

        if(generatorService == null)
        {
            return;
        }

        generatorService.GenerateBusinessModelByName(control.Name);

        previewControlBM = generatorService.GetModel<PreviewControlBusinessModel>();

        OnPropertyChanged(nameof(CollectionIsVisible));
    }

    [RelayCommand]
    private void NewProject()
    {
        previewControlBM?.NewProject();
    }

    [RelayCommand]
    private void LoadProject()
    {
        previewControlBM?.LoadProject();

        windowViewModel?.NavigateToControl<MenuControl>();
    }
}

