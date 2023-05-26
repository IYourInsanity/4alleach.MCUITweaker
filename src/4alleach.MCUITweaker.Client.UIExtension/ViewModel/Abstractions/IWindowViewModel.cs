using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCUITweaker.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public interface IWindowViewModel : IBaseViewModel
{
    void SetWindow<TWindow>(TWindow window) 
        where TWindow : IExtendedWindow;

    TWindow? GetWindow<TWindow>() 
        where TWindow : class, IExtendedWindow;

    void RegisterControl(IExtendedControl control);

    void UnregisterControl(IExtendedControl control);

    void KeyPress(Key key);
}
