using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Control.ContextMenu;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls.ContextMenu;

public partial class StandardContextMenu : ContextMenuControl
{
    public StandardContextMenu() : base(nameof(StandardContextMenu))
    {
        InitializeComponent();

        DataContext = new StandardContextMenuViewModel();
    }
}
