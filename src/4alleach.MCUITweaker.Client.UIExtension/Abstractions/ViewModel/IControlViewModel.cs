using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

public interface IControlViewModel : IBaseViewModel
{
    void SetControl<TExtendedControl>(TExtendedControl control)
        where TExtendedControl : IExtendedControl;

    TExtendedControl? GetControl<TExtendedControl>()
        where TExtendedControl : class, IExtendedControl;

    bool SetChildViewModel<TViewModel>(TViewModel model) where TViewModel : class, IControlViewModel;

    TViewModel? GetChildViewModel<TViewModel>() where TViewModel : class, IControlViewModel;
}
