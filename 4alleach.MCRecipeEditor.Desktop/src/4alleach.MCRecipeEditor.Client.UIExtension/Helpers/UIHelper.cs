using System.Windows;
using System.Windows.Media;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;

public static class UIHelper
{
    public static void UpdateUI(Action action)
    {
        if (action == null || Application.Current == null)
        {
            return;
        }

        var dispatcher = Application.Current.Dispatcher;

        if (dispatcher.CheckAccess())
        {
            action();
        }
        else
        {
            try
            {
                dispatcher.Invoke(action);
            }
            catch (TaskCanceledException) { }
        }
    }

    public static DependencyObject? TryFindChild(this DependencyObject obj, Func<DependencyObject, bool> funcCondition)
    {
        // Iterate through all immediate children
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        {
            var contentElement = VisualTreeHelper.GetChild(obj, i);

            if (funcCondition(contentElement) == true)
            {
                return contentElement;
            }

            var childOfChild = TryFindChild(contentElement, funcCondition);
            if (childOfChild != null)
            {
                return childOfChild;
            }
        }

        return null;
    }
}
