using _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.Extensions;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakMechanics.Recipes;
using _4alleach.MCRecipeEditor.Models.CraftTweak.Enumerable;
using _4alleach.MCRecipeEditor.Models.Services.Project;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls.CraftTweakMechanics;

internal sealed partial class MainCraftControlViewModel : ControlViewModel<IExtendedWindowViewModel>
{
    [ObservableProperty]
    private RecipeProject? recipe;

    [ObservableProperty]
    private ObservableCollection<Tuple<RecipeType, string>>? recipeTypeList;

    private RecipeType recipeType;
    public RecipeType RecipeType
    {
        get => recipeType;
        set
        {
            recipeType = value;

            if(Recipe != null)
            {
                Recipe.Type = value;
            }

            ShowControlByType(value);
            OnPropertyChanged(nameof(RecipeType));
        }
    }

    public MainCraftControlViewModel(Grid container) : base(container)
    {
        recipeType = RecipeType.None;
    }

    public override void Initialize()
    {
        base.Initialize();

        var recipeTypeDescriptionList = new List<string>()
        {
            "None",
            "Add shaped",
            "Remove shaped"
        };

        var recipeTypeList = EnumExtension.GetAllValuesAndDescriptionsWithCustomNames<RecipeType>(recipeTypeDescriptionList);

        RecipeTypeList = new ObservableCollection<Tuple<RecipeType, string>>(recipeTypeList);

        RegisterControl<AddShapedCraftControl>();
        RegisterControl<RemoveShapedCraftControl>();
    }

    public override void SetArguments(params object[]? args)
    {
        if(args != null && args.Length > 0)
        {
            Recipe = (RecipeProject)args[0];

            RecipeType = Recipe.Type;
        }
    }

    private void ShowControlByType(RecipeType type)
    {
        switch(type)
        {
            case RecipeType.None: HideLatestControl();
                break;
            case RecipeType.AddShaped: ShowControl<AddShapedCraftControl>();
                break;
            case RecipeType.RemoveShaped: ShowControl<RemoveShapedCraftControl>();
               break;
        }
    }
}
