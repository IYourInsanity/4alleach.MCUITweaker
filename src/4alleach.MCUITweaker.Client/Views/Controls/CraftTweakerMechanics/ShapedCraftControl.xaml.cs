using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Controls.CraftTweakerMechanics;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls.CraftTweakerMechanics
{

    public partial class ShapedCraftControl : ExtendedControl
    {
        public ShapedCraftControl() : base(nameof(ShapedCraftControl))
        {
            InitializeComponent();

            DataContext = new ShapedCraftControlViewModel();
        }
    }
}
