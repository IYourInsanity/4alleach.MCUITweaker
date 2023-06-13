using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;

public interface IElementStorage<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    void Register<TRegisterElement>(TElement? parent = null)
        where TRegisterElement : TElement;

    void Unregister<TRegisterElement>() 
        where TRegisterElement : TElement;

    TRegisterElement? Get<TRegisterElement>() 
        where TRegisterElement : TElement;
}
