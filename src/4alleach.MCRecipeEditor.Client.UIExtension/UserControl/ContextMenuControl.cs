using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic;
using _4alleach.MCRecipeEditor.Client.UIExtension.Logic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;

public class ContextMenuControl : System.Windows.Controls.UserControl, IContextMenuElement
{
    public Guid VID { get; }

    public new string Name { get; }

    public FrameworkElement Value => this;

    private IContextMenuViewModel ViewModel => (IContextMenuViewModel)DataContext;

    private Panel? parent;

    private IElementContainer? parentContainer;


    public ContextMenuControl(string name) : base()
    {
        VID = Guid.NewGuid();
        Name = name;
    }

    public void Initialize(Panel parent)
    {
        this.parent = parent;
        this.parentContainer = new ElementContainer(parent);
    }

    public void Hide()
    {
        parentContainer?.TryRemove(this);  
    }

    public void Show(MouseButtonEventArgs e)
    {
        if (parent == null)
        {
            throw new NotImplementedException();
        }

        parentContainer?.TryAdd(this);

        ViewModel.Setup(e.GetPosition(parent), parent.RenderSize);
    }

    public void Remove<TContextItemContent>(TContextItemContent content) 
        where TContextItemContent : FrameworkElement
    {
        ViewModel?.Remove(content);
    }

    public void Add<TContextItemContent>(string content, ICommand command, Style? style = null) 
        where TContextItemContent : FrameworkElement
    {
        var instance = Activator.CreateInstance<TContextItemContent>();

        instance.SetValue(ContentProperty, content);
        instance.SetValue(Button.CommandProperty, command);

        if(style != null)
        {
            instance.SetValue(StyleProperty, style);
        }

        ViewModel?.Add(instance);
    }

    public void Add<TContextItemContent>(Style? style = null) 
        where TContextItemContent : FrameworkElement
    {
        var instance = Activator.CreateInstance<TContextItemContent>();

        if (style != null)
        {
            instance.SetValue(StyleProperty, style);
        }

        ViewModel?.Add(instance);
    }
}
