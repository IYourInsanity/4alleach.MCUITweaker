using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.Logic.Modules;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions.ViewModel;
using _4alleach.MCRecipeEditor.Client.UIExtension.Abstractions;
using _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;
using Microsoft.Xaml.Behaviors;
using System.Windows.Input;
using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Behaviors.ContextMenu;
public sealed class ContextMenuBehavior : Behavior<FrameworkElement>
{
    protected override void OnAttached()
    {
        base.OnAttached();
        this.AssociatedObject.MouseRightButtonDown += AssociatedObject_MouseRightButtonDown;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();
        this.AssociatedObject.MouseRightButtonDown -= AssociatedObject_MouseRightButtonDown;
    }

    public static void AssociatedObject_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is FrameworkElement element &&
           element.DataContext is IExtendedFrameworkElementViewModel model)
        {
            var identifier = (string)element.GetValue(ContextMenuHelper.IdentifierProperty);

            if (identifier == string.Empty)
            {
                return;
            }

            model.GetElement<IExtendedFrameworkElement>()?.Provider
                 .GetProviderModule<IContextMenuProvider>()?
                 .Show(identifier, e);
        }
    }
}
