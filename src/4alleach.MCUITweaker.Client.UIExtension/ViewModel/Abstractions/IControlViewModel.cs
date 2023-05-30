using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

public interface IControlViewModel : IBaseViewModel, IRegisterControl
{
    void SetControl<TControl>(TControl control) where TControl : IExtendedControl;

    TControl? GetControl<TControl>() where TControl : class, IExtendedControl;

    bool SetChildViewModel<TViewModel>(TViewModel model) where TViewModel : class, IControlViewModel;

    TViewModel? GetChildViewModel<TViewModel>() where TViewModel : class, IControlViewModel;
}
