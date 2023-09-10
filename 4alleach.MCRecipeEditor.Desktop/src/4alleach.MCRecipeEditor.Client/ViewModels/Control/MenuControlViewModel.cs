using _4alleach.MCRecipeEditor.Client.BusinessModels;
using _4alleach.MCRecipeEditor.Client.Extensions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakMechanic;
using _4alleach.MCRecipeEditor.Models.Services.Project;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Control;
public sealed partial class MenuControlViewModel : ControlViewModel
{
    private readonly MenuControlBusinessModel businessModel;

    private ObservableCollection<FileProject> fileCollection;
    public ObservableCollection<FileProject>? FileCollection => fileCollection.Update(businessModel?.FileCollection);

    private ObservableCollection<RecipeProject> recipeCollection;
    public ObservableCollection<RecipeProject>? RecipeCollection => recipeCollection.Update(businessModel?.RecipeCollection);

    public FileProject? SelectedFileProject
    {
        get => businessModel?.selectedFileProject;
        set
        {
            if(businessModel == null)
            {
                return;
            }

            businessModel.selectedFileProject = value;

            IsFileSelected = value != null;

            OnPropertyChanged(nameof(RecipeCollection));
        }
    }

    public RecipeProject? SelectedRecipeProject
    {
        get => businessModel?.selectedRecipeProject;
        set
        {
            if (businessModel == null)
            {
                return;
            }

            IsRecipeSelected = value != null;

            businessModel.selectedRecipeProject = value;

            if(value == null)
            {
                provider.HideLast();
            }
            else
            {
                provider.Show<MainCraftControl>(value);
            }
        }
    }

    [ObservableProperty]
    private bool isFileSelected;

    [ObservableProperty]
    private bool isRecipeSelected;

    [RelayCommand]
    private void AddNewFile()
    {
        businessModel?.AddNewFile();

        OnPropertyChanged(nameof(FileCollection));
        OnPropertyChanged(nameof(SelectedFileProject));
    }

    [RelayCommand]
    private void AddNewRecipe()
    {
        businessModel?.AddNewRecipe();

        OnPropertyChanged(nameof(RecipeCollection));
        OnPropertyChanged(nameof(SelectedRecipeProject));
    }

    public MenuControlViewModel(Grid container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
    {
        fileCollection = new ObservableCollection<FileProject>();
        recipeCollection = new ObservableCollection<RecipeProject>();
        businessModel = new MenuControlBusinessModel();
    }

    public override void Initialize()
    {
        base.Initialize();

        businessModel.Initialize();

        provider.Register<MainCraftControl>(control);
    }
}
