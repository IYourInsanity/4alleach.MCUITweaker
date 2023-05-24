using System.Windows;

namespace _4alleach.MCUITweaker.Client.UIExtension.Helpers;

public class UIHelper
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
}
