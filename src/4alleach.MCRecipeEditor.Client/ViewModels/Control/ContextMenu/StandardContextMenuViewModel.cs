using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu.ViewModel;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Control.ContextMenu;

public sealed partial class StandardContextMenuViewModel : ContextMenuViewModel
{
    protected override double ItemWidth => 200;

    protected override double ItemHeight => 18;

    public StandardContextMenuViewModel(): base()
    {

    }
}
