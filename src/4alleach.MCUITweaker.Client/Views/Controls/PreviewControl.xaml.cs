using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Controls;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls;

public partial class PreviewControl : ExtendedControl
{
    public PreviewControl() : base(typeof(PreviewControlViewModel), nameof(PreviewControl))
    {
        InitializeComponent();
    }
}
