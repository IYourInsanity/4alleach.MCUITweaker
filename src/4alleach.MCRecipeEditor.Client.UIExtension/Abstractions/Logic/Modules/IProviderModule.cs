using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;

public interface IProviderModule<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    void Initialize(IElementProvider<TElement, TViewModel> provider, params object[]? args);
}
