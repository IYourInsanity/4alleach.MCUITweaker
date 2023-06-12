using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Window;

public class ExtendedModalWindow<TResult> : System.Windows.Window, IExtendedModalWindow 
    where TResult : class
{
    public Guid VID { get; }

    public new string Name { get; }

    public FrameworkElement Value => throw new NotImplementedException();

    public IElementProvider<IExtendedModalWindow, IModalWindowViewModel> Provider => throw new NotImplementedException();

    public UIElementCollection Children => throw new NotImplementedException();

    public ExtendedModalWindow(IModalWindowViewModel viewModel, string name) : base()
    {
        DataContext = viewModel;

        VID = Guid.NewGuid();
        Name = name;
    }
}
