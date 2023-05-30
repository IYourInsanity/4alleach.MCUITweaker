using _4alleach.MCRecipeEditor.Client.Abstractions.ViewModels;
using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Models.Services.Project;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Controls.CraftTweakerMechanics;

internal sealed partial class ShapedCraftControlViewModel : ControlViewModel<IExtendedWindowViewModel>
{
    [ObservableProperty]
    private RecipeProject? recipe;

    public ShapedCraftControlViewModel() : base()
    {

    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void SetArguments(params object[]? args)
    {
        if(args != null)
        {
            Recipe = (RecipeProject)args[0];
        }
    }
}
