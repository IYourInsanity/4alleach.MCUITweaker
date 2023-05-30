using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IWindowViewModel : IBaseViewModel, IRegisterControl
{
    void SetWindow<TWindow>(TWindow window) 
        where TWindow : IExtendedWindow;

    TWindow? GetWindow<TWindow>() 
        where TWindow : class, IExtendedWindow;

    void KeyPress(Key key);
}
