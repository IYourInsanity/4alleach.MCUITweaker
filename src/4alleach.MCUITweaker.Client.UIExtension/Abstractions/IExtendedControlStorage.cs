using _4alleach.MCUITweaker.Client.UIExtension.UserControl.Abstractions;

namespace _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

public interface IExtendedControlStorage<TExtendedControl> 
    where TExtendedControl : class, IExtendedControl
{
    void Register<VExtendedControl>() where VExtendedControl : TExtendedControl;
    void Unregister<VExtendedControl>() where VExtendedControl : TExtendedControl;

    void Navigate<VExtendedControl>() where VExtendedControl : TExtendedControl;
}
