using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Control;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls;

public partial class PreviewControl : ExtendedControl
{
    public PreviewControl() : base(nameof(PreviewControl))
    {
        InitializeComponent();

        DataContext = new PreviewControlViewModel(Provider);
    }
}
