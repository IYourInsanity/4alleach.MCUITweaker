using _4alleach.MCUITweaker.Client.UIExtension.UserControl;
using _4alleach.MCUITweaker.Client.ViewModels.Controls;

namespace _4alleach.MCUITweaker.Client.Views.Control;

public partial class PreviewControl : ExtendedControl
{
    public PreviewControl() : base(typeof(PreviewControlViewModel), nameof(PreviewControl))
    {
        InitializeComponent();
    }
}
