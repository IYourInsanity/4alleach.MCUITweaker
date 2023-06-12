using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;

public interface IElementController<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    void Show<TExtendedElement>(params object[]? args) where TExtendedElement : TElement;

    void Hide<TExtendedElement>() where TExtendedElement : TElement;

    void Register<TExtendedElement>(TElement? parent) where TExtendedElement : TElement;

    void Unregister<TExtendedElement>() where TExtendedElement : TElement;
}
