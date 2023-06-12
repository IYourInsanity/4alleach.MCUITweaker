using _4alleach.MCRecipeEditor.Client.UIExtension.Window.Abstractions;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public interface IWindowViewModel : IBaseViewModel
{
    void SetWindow<TExtendedWindow>(TExtendedWindow window)
        where TExtendedWindow : IExtendedWindow;

    TExtendedWindow? GetWindow<TExtendedWindow>()
        where TExtendedWindow : class, IExtendedWindow;

    void KeyPress(Key key);
}
