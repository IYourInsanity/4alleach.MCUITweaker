using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ElementController<TElement, TViewModel> : IElementController<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    private readonly TElement host;

    private readonly IElementStorage<TElement, TViewModel> storage;

    private IElementContainer? container;

    private TElement? visibleControl;

    internal ElementController(TElement host)
    {
        this.host = host;

        storage = new ElementStorage<TElement, TViewModel>();
    }

    public void Initialize()
    {
        container = host.Provider.Container;
    }

    public void Show<TExtendedElement>(params object[]? args) 
        where TExtendedElement : TElement
    {
        var control = storage.Get<TExtendedElement>();

        if(control == null)
        {
            //TODO Implement exception
            return;
        }

        var controlHost = control.Provider.Host;

        control.Provider.SetArguments(args);

        if (container?.Contains(controlHost) == true)
        {
            return;
        }

        container?.TryAdd(controlHost);

        if (visibleControl != null && 
            visibleControl.GetType() != control.GetType())
        {
            var currentControlHost = visibleControl?.Provider.Host;
            container?.TryRemove(currentControlHost);
        }

        visibleControl = control;
    }

    public void Hide<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        var control = storage.Get<TExtendedElement>();

        if (control == null)
        {
            //TODO Implement exception
            return;
        }

        var controlHost = control.Provider.Host;

        container?.TryRemove(controlHost);

        visibleControl = null;
    }

    public void HideLast()
    {
        if(visibleControl == null)
        {
            return;
        }

        container?.TryRemove(visibleControl.Provider.Host);

        visibleControl = null;
    }

    public void Register<TExtendedElement>(TElement? parent)
        where TExtendedElement : TElement
    {
        container ??= host.Provider.Container;

        storage.Register<TExtendedElement>(parent);
    }

    public void Unregister<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        storage.Unregister<TExtendedElement>();
    }
}
