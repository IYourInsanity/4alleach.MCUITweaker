using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Window;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Logic.Modules;
public sealed class ModalWindowProvider : IModalWindowProvider
{
    private readonly Dictionary<Type, ExtendedModalWindow> storage;

    private IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel>? provider;

    public ModalWindowProvider()
    {
        storage = new Dictionary<Type, ExtendedModalWindow>();
    }

    public void Initialize(IElementProvider<IExtendedFrameworkElement, IExtendedFrameworkElementViewModel> provider, params object[]? args)
    {
        this.provider = provider;
    }

    public TModalResult? ShowModal<TModalElement, TModalResult>(params object[]? args)
        where TModalElement : ExtendedModalWindow, new()
        where TModalResult : class
    {
        var type = typeof(TModalElement);

        if (storage.TryGetValue(type, out var modalWindow))
        {
            return ShowModalInternal<TModalResult>(modalWindow, args);
        }

        modalWindow = Activator.CreateInstance<TModalElement>();

        storage.Add(type, modalWindow);

        return ShowModalInternal<TModalResult>(modalWindow, args);
    }

    private static TModalResult? ShowModalInternal<TModalResult>(ExtendedModalWindow modalWindow, params object[]? args)
        where TModalResult : class
    {
        modalWindow.Provider.SetArguments(args);

        modalWindow.ShowDialog();

        return modalWindow.DialogResult as TModalResult;
    }
}
