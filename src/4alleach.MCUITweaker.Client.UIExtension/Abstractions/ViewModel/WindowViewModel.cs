using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public abstract partial class WindowViewModel : BaseViewModel, IWindowViewModel
{
    protected IExtendedWindow? window;

    public WindowViewModel(Grid container) : base()
    {

    }

    public void SetWindow<TExtendedWindow>(TExtendedWindow window)
        where TExtendedWindow : IExtendedWindow
    {
        this.window = window;
    }

    public TExtendedWindow? GetWindow<TExtendedWindow>()
        where TExtendedWindow : class, IExtendedWindow
    {
        return window as TExtendedWindow;
    }

    public override TFrameworkElement? FindElement<TFrameworkElement>(string name)
        where TFrameworkElement : class
    {
        if (window == null)
        {
            return default;
        }

        return window.Provider.FindElement<TFrameworkElement>(name);
    }

    public void KeyPress(Key key)
    {
        throw new NotImplementedException();
    }
}
