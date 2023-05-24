using _4alleach.MCUITweaker.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class WindowViewModel : BaseViewModel, IWindowViewModel
{
    protected IExtendedWindow? window;

    public WindowViewModel(): base()
    {

    }

    public void SetWindow<TWindow>(TWindow window) where TWindow : IExtendedWindow
    {
        this.window = window;
    }

    public TWindow? GetWindow<TWindow>() where TWindow : class, IExtendedWindow
    {
        return window as TWindow;
    }

    public override TFrameworkElement FindElement<TFrameworkElement>(string name)
    {
        return window!.Picker.FindElement<TFrameworkElement>(name);
    }

    public void KeyPress(Key key)
    {
        throw new NotImplementedException();
    }
}
