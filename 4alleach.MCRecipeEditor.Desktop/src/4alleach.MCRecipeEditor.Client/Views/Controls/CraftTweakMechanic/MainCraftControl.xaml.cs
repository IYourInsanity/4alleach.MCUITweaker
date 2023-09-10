using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Control.CraftTweakMechanic;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakMechanic;

public partial class MainCraftControl : ExtendedControl
{
    public MainCraftControl() : base(nameof(MainCraftControl))
    {
        InitializeComponent();

        DataContext = new MainCraftControlViewModel(Container, Provider);
    }
}
