using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;

public interface IElementController<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    void Initialize();

    void Show<TExtendedElement>(params object[]? args) 
        where TExtendedElement : TElement;

    void Hide<TExtendedElement>() 
        where TExtendedElement : TElement;

    void HideLast();

    void Register<TExtendedElement>(TElement? parent = null) 
        where TExtendedElement : TElement;

    void Unregister<TExtendedElement>() 
        where TExtendedElement : TElement;

    public void RegisterProviderModule<TProviderModuleInterface, TProviderModuleImplementation>(params object[]? args)
        where TProviderModuleInterface : IProviderModule<TElement, TViewModel>
        where TProviderModuleImplementation : class, IProviderModule<TElement, TViewModel>;

    public TProviderModule? GetProviderModule<TProviderModule>()
        where TProviderModule : IProviderModule<TElement, TViewModel>;
}
