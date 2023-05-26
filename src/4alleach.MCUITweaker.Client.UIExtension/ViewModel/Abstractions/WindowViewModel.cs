using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public abstract partial class WindowViewModel : BaseViewModel, IWindowViewModel
{
    protected IExtendedWindow? window;

    protected IList<IExtendedControl> controls;

    public WindowViewModel(): base()
    {
        controls = new List<IExtendedControl>();
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

    public void RegisterControl(IExtendedControl control)
    {
        controls.Add(control);
    }

    public void UnregisterControl(IExtendedControl control)
    {
        controls.Remove(control);
    }
}
