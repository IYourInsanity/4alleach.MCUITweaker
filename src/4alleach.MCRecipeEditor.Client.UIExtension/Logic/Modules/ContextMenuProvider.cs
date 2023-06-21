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
    private readonly Dictionary<Type, IContextMenuElement> storage;

    private IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>? provider;

    public ContextMenuProvider()
    {
        storage = new Dictionary<Type, IContextMenuElement>();
    }

    public void Initialize(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
    {
        this.provider = provider;
    }

    public void Register<TCreator, TContextMenu>(string containerName, Action<TContextMenu> registerCallback)
        where TCreator : IExtendedFrameworkElementViewModel
        where TContextMenu : IContextMenuElement
    {
        var creatorType = typeof(TCreator);

        if(provider == null || provider.Container == null)
        {
            throw new NotImplementedException();
        }

        if (storage.ContainsKey(creatorType) == true)
        {
            throw new NotImplementedException();
        }

        var contextMenu = Activator.CreateInstance<TContextMenu>();
        var container = provider.FindElement<Panel>(containerName);

        if(container == null) 
        {
            throw new NotImplementedException();
        }

        contextMenu.Initialize(container);

        registerCallback(contextMenu);

        storage.Add(creatorType, contextMenu);
    }

    public void Show<TCreator>(MouseButtonEventArgs e) 
        where TCreator : IExtendedFrameworkElementViewModel
    {
        var creatorType = typeof(TCreator);

        if(storage.TryGetValue(creatorType, out var contextMenu))
        {
            contextMenu.Show(e);
            return;
        }

        throw new NotImplementedException();
    }
}
