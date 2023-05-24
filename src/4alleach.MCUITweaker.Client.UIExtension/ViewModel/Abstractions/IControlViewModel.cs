using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

public interface IControlViewModel : IBaseViewModel
{
    void SetControl<TControl>(TControl control) where TControl : IExtendedControl;

    TControl? GetControl<TControl>() where TControl : class, IExtendedControl;

    bool SetChildViewModel<TViewModel>(TViewModel model) where TViewModel : class, IControlViewModel;

    TViewModel? GetParentViewModel<TViewModel>() where TViewModel : class, IControlViewModel;

    TViewModel? GetChildViewModel<TViewModel>() where TViewModel : class, IControlViewModel;
}
