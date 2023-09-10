using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ContextMenu.ViewModel;
public abstract partial class ContextMenuViewModel : ObservableObject, IContextMenuViewModel
{
    protected abstract double ItemWidth { get; }
    protected abstract double ItemHeight { get; }

    protected double ItemsHeight { get; private set; }

    [ObservableProperty]
    private double positionX;

    [ObservableProperty]
    private double positionY;

    [ObservableProperty]
    private List<FrameworkElement> itemCollection;

    protected ContextMenuViewModel() : base()
    {
        itemCollection = new List<FrameworkElement>();
    }

    public void Add<TContextItemContent>(TContextItemContent element)
        where TContextItemContent : FrameworkElement
    {
        SetupElement(element);
        ItemCollection.Add(element);
        CalculateItemsHeight();
    }

    public void Remove<TContextItemContent>(TContextItemContent element) 
        where TContextItemContent : FrameworkElement
    {
        ItemCollection.Remove(element);
        CalculateItemsHeight();
    }

    public void Setup(Point position, Size size)
    {
        var width = size.Width;
        var height = size.Height;

        var positionX = position.X;
        var positionY = position.Y;

        if (width - positionX < ItemWidth)
        {
            PositionX = positionX - ItemWidth;
        }
        else
        {
            PositionX = positionX;
        }

        if (height - positionY < ItemsHeight)
        {
            PositionY = positionY - ItemsHeight;
        }
        else
        {
            PositionY = positionY;
        }
    }

    private void CalculateItemsHeight()
    {
        ItemsHeight = ItemHeight * ItemCollection.Count + 16;
    }

    private void SetupElement<TContextItemContent>(TContextItemContent content)
        where TContextItemContent : FrameworkElement
    {
        if(content is Separator)
        {
            return;
        }

        content.Height = ItemHeight;
        content.Width = ItemWidth;
    }

}
