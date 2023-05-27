using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IWindowViewModel : IBaseViewModel
{
    void SetWindow<TWindow>(TWindow window) 
        where TWindow : IExtendedWindow;

    TWindow? GetWindow<TWindow>() 
        where TWindow : class, IExtendedWindow;

    void RegisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl;

    void UnregisterControl<VExtendedControl>() where VExtendedControl : IExtendedControl;

    void NavigateToControl<VExtendedControl>() where VExtendedControl : IExtendedControl;

    void KeyPress(Key key);
}
