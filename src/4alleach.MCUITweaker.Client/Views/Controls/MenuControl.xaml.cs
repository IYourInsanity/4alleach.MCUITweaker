using _4alleach.MCUITweaker.Client.UIExtension.UserControl;
using _4alleach.MCUITweaker.Client.ViewModels.Controls;

namespace _4alleach.MCUITweaker.Client.Views.Controls;

public partial class MenuControl : ExtendedControl
{
    public MenuControl() : base(typeof(MenuControlViewModel), nameof(MenuControl))
    {
        InitializeComponent();
    }
}
