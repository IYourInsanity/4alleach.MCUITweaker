using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.ViewModels.Control.ContextMenu;

public sealed partial class StandardContextMenuViewModel : ContextMenuViewModel
{
    protected override double ItemWidth => 200;

    protected override double ItemHeight => 24;

    public StandardContextMenuViewModel(): base()
    {

    }
}
