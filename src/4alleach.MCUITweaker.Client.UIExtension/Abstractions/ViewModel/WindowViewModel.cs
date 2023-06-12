using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public abstract partial class WindowViewModel : BaseViewModel, IExtendedFrameworkElementViewModel
{
    protected IExtendedFrameworkElement? window;

    public WindowViewModel(Grid container) : base()
    {

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

    public void SetElement<TExtendedElement>(TExtendedElement window)
        where TExtendedElement : class, IExtendedFrameworkElement
    {
        this.window = window;
    }

    public TExtendedElement? GetElement<TExtendedElement>()
        where TExtendedElement : class, IExtendedFrameworkElement
    {
        return window as TExtendedElement;
    }

    public bool SetChildViewModel<TViewModel>(TViewModel model)
        where TViewModel : class, IExtendedFrameworkElementViewModel
    {
        throw new NotImplementedException();
    }

    public TViewModel? GetChildViewModel<TViewModel>()
        where TViewModel : class, IExtendedFrameworkElementViewModel
    {
        throw new NotImplementedException();
    }
}
