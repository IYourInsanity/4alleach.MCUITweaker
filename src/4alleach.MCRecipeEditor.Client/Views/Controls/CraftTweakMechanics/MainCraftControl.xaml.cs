using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Controls.CraftTweakMechanics;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakMechanics;

public partial class MainCraftControl : ExtendedControl
{
    public MainCraftControl() : base(nameof(MainCraftControl))
    {
        InitializeComponent();

        DataContext = new MainCraftControlViewModel(Container, Provider);
    }
}
