using _4alleach.MCUITweaker.Client.UIExtension.ViewModel.Abstractions;

namespace _4alleach.MCUITweaker.Client.UIExtension.Abstractions;

public interface IBaseElement<TViewModel> where TViewModel : class, IBaseViewModel
{
    string Name { get; }

    Guid VID { get; }

    IExtendedPicker<TViewModel> Picker { get; }
}
