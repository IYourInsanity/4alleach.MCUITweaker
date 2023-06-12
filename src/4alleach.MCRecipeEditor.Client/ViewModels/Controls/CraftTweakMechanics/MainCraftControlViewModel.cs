using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Extensions;
using _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakMechanics.Recipes;
using _4alleach.MCRecipeEditor.Models.CraftTweak.Enumerable;
using _4alleach.MCRecipeEditor.Models.Services.Project;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls.CraftTweakMechanics;

internal sealed partial class MainCraftControlViewModel : ControlViewModel
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

    public MainCraftControlViewModel(Grid container, IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider) : base(container, provider)
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

        provider.Register<AddShapedCraftControl>(control);
        provider.Register<RemoveShapedCraftControl>(control);
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
            case RecipeType.None: provider.HideLast();
                break;
            case RecipeType.AddShaped: provider.Show<AddShapedCraftControl>();
                break;
            case RecipeType.RemoveShaped: provider.Show<RemoveShapedCraftControl>();
               break;
        }
    }
}
