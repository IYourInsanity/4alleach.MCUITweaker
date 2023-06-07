using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

public interface IExtendedControlStorage<TExtendedControl>
    where TExtendedControl : class, IExtendedControl
{
    void Register<VExtendedControl>(TExtendedControl? parent) where VExtendedControl : TExtendedControl;
    void Unregister<VExtendedControl>() where VExtendedControl : TExtendedControl;

    void Show<VExtendedControl>(params object[]? args) where VExtendedControl : TExtendedControl;

    void Hide<VExtendedControl>() where VExtendedControl : TExtendedControl;

    void HideLatest();
}
