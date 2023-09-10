using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ElementStorage<TElement, TViewModel> : IElementStorage<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    private readonly Dictionary<Type, TElement> storage;

    internal ElementStorage()
    {
        storage = new Dictionary<Type, TElement>();
    }

    public void Register<TRegisterElement>(TElement? parent) 
        where TRegisterElement : TElement
    {
        var control = Activator.CreateInstance<TRegisterElement>();
        var type = control.GetType();

        storage.Add(type, control);

        if (parent != null)
        {
            control.Provider.SetParent(parent.Provider.Host);
        }
    }

    public void Unregister<TRegisterElement>() 
        where TRegisterElement : TElement
    {
        storage.Remove(typeof(TRegisterElement));
    }

    public TRegisterElement? Get<TRegisterElement>() 
        where TRegisterElement : TElement
    {
        if(storage.TryGetValue(typeof(TRegisterElement), out var control))
        {
            return (TRegisterElement)control;
        }

        return default;
    }    
}
