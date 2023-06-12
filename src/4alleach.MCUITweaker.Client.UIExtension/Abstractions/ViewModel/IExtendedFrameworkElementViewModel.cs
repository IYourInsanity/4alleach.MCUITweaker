using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public interface IExtendedFrameworkElementViewModel : IBaseViewModel
{
    void SetElement<TExtendedElement>(TExtendedElement window)
        where TExtendedElement : class, IExtendedFrameworkElement;

    TExtendedElement? GetElement<TExtendedElement>()
        where TExtendedElement : class, IExtendedFrameworkElement;

    bool SetChildViewModel<TViewModel>(TViewModel model)
        where TViewModel : class, IExtendedFrameworkElementViewModel;

    TViewModel? GetChildViewModel<TViewModel>() 
        where TViewModel : class, IExtendedFrameworkElementViewModel;

    void KeyPress(Key key);
}
