using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Window;

public class ExtendedModalWindow<TResult> : System.Windows.Window, IExtendedFrameworkElement
    where TResult : class
{
    public Guid VID { get; }

    public new string Name { get; }

    public FrameworkElement Value => throw new NotImplementedException();

    public IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> Provider => throw new NotImplementedException();

    public UIElementCollection Children => throw new NotImplementedException();

    public ExtendedModalWindow(IExtendedFrameworkElementViewModel viewModel, string name) : base()
    {
        DataContext = viewModel;

        VID = Guid.NewGuid();
        Name = name;
    }
}
