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
        if(parent == null)
        {
            throw new NotImplementedException();
        }

        parentContainer?.TryAdd(this);
        ViewModel.Setup(e.GetPosition(parent), parent.RenderSize);
    }

    protected virtual void CanvasMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        Hide();
    }

    public void Add<TContextItemContent>(TContextItemContent content) 
        where TContextItemContent : FrameworkElement
    {
        ViewModel?.Add(content);
    }

    public void Remove<TContextItemContent>(TContextItemContent content) 
        where TContextItemContent : FrameworkElement
    {
        ViewModel?.Remove(content);
    }
}
