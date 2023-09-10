using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Window;

public abstract class ExtendedModalWindow : System.Windows.Window, IExtendedFrameworkElement
{
    public Guid VID { get; }

    public FrameworkElement Value => this;

    public IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> Provider { get; }

    public ExtendedModalWindow() : base()
    {
        VID = Guid.NewGuid();
        Provider = new ElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>(this);
    }

    public abstract Task<IModalResult> AwaitResult();
}

public interface IModalResult
{

}
