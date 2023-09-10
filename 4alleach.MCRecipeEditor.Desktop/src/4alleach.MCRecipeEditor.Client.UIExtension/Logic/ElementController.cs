using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic;

internal sealed class ElementController<TElement, TViewModel> : IElementController<TElement, TViewModel>
    where TElement : class, IBaseElement<TElement, TViewModel>
    where TViewModel : class, IBaseViewModel
{
    private readonly TElement host;

    private readonly IElementStorage<TElement, TViewModel> elementStorage;

    private readonly Dictionary<Type, IProviderModule<TElement, TViewModel>> moduleStorage;

    private IElementContainer? container;

    private TElement? visibleElement;

    internal ElementController(TElement host)
    {
        this.host = host;

        elementStorage = new ElementStorage<TElement, TViewModel>();
        moduleStorage = new Dictionary<Type, IProviderModule<TElement, TViewModel>>();
    }

    public void Initialize()
    {
        container = host.Provider.Container;
    }

    public void Show<TExtendedElement>(params object[]? args) 
        where TExtendedElement : TElement
    {
        var element = elementStorage.Get<TExtendedElement>();

        if(element == null)
        {
            //TODO Implement exception
            return;
        }

        var elementHost = element.Provider.Host;

        element.Provider.SetArguments(args);

        if (container?.Contains(elementHost) == true)
        {
            return;
        }

        container?.TryAdd(elementHost);

        if (visibleElement != null &&
            visibleElement.GetType() != element.GetType())
        {
            var currentControlHost = visibleElement?.Provider.Host;
            container?.TryRemove(currentControlHost);
        }

        visibleElement = element;
    }

    public TModalResult? ShowModal<TModalElement, TModalResult>(params object[]? args)
        where TModalElement : ExtendedModalWindow, TElement
    {
        var modalElement = Activator.CreateInstance<TModalElement>();

        modalElement.Owner = Application.Current.MainWindow;
        modalElement.ShowDialog();

        return default;
    }

    public void Hide<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        var control = elementStorage.Get<TExtendedElement>();

        if (control == null)
        {
            //TODO Implement exception
            return;
        }

        var controlHost = control.Provider.Host;

        container?.TryRemove(controlHost);

        visibleElement = null;
    }

    public void HideLast()
    {
        if(visibleElement == null)
        {
            return;
        }

        container?.TryRemove(visibleElement.Provider.Host);

        visibleElement = null;
    }

    public void Register<TExtendedElement>(TElement? parent)
        where TExtendedElement : TElement
    {
        elementStorage.Register<TExtendedElement>(parent);
    }

    public void Unregister<TExtendedElement>() 
        where TExtendedElement : TElement
    {
        elementStorage.Unregister<TExtendedElement>();
    }

    public void RegisterProviderModule<TProviderModuleInterface, TProviderModuleImplementation>(params object[]? args) 
        where TProviderModuleInterface : IProviderModule<TElement, TViewModel>
        where TProviderModuleImplementation : class, IProviderModule<TElement, TViewModel>
    {
        var control = Activator.CreateInstance<TProviderModuleImplementation>();
        var type = typeof(TProviderModuleInterface);

        control.Initialize(host.Provider, args);

        moduleStorage.Add(type, control);
    }

    public TProviderModule? GetProviderModule<TProviderModule>() 
        where TProviderModule : IProviderModule<TElement, TViewModel>
    {
        var type = typeof(TProviderModule);

        if (moduleStorage.TryGetValue(type, out var module))
        {
            return (TProviderModule?)module;
        }

        throw new NotImplementedException();
    }
}
