using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic.Modules;

public sealed class ContextMenuProvider : IContextMenuProvider
{
    private const string CONTAINER_NAME = "ContextMenuContainer";

    private readonly Dictionary<string, IContextMenuElement> storage;

    private Panel? container;

    private IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>? provider;

    private IContextMenuElement? previousContextMenu;

    public ContextMenuProvider()
    {
        storage = new Dictionary<string, IContextMenuElement>();
    }

    public void Initialize(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
    {
        this.provider = provider;
        this.container = provider.FindElement<Panel>(CONTAINER_NAME);
    }

    public void Register<TContextMenu>(string key, Action<TContextMenu> registerCallback)
        where TContextMenu : IContextMenuElement
    {
        if(provider == null || provider.Container == null)
        {
            throw new NotImplementedException();
        }

        if (storage.ContainsKey(key) == true)
        {
            throw new NotImplementedException();
        }

        var contextMenu = Activator.CreateInstance<TContextMenu>();
        
        if(container == null) 
        {
            throw new NotImplementedException();
        }

        contextMenu.Initialize(container);

        registerCallback(contextMenu);

        storage.Add(key, contextMenu);
    }

    public void Show(string key, MouseButtonEventArgs e) 
    {
        if(storage.TryGetValue(key, out var contextMenu))
        {
            ChangeVisibility(System.Windows.Visibility.Visible);
            contextMenu.Show(e);

            previousContextMenu = contextMenu;

            return;
        }

        throw new NotImplementedException();
    }

    public void Hide()
    {
        ChangeVisibility(System.Windows.Visibility.Hidden);
        previousContextMenu?.Hide();
    }

    private void ChangeVisibility(System.Windows.Visibility visible)
    {
        if (container == null)
        {
            throw new NotImplementedException();
        }

        container.Visibility = visible;
    }
}
