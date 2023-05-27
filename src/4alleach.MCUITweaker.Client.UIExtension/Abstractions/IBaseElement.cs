using _4alleach.MCRecipeEditor.Client.UIExtension.ViewModel.Abstractions;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;

public interface IBaseElement<TViewModel> where TViewModel : class, IBaseViewModel
{
    string Name { get; }

    Guid VID { get; }

    IExtendedPicker<TViewModel> Picker { get; }
}
