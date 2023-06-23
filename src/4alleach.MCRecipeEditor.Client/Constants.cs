using System.Windows;
using System.Windows.Media;
using _4alleach.MCRecipeEditor.Client.Properties;
using _4alleach.MCRecipeEditor.Common.Extensions;

namespace _4alleach.MCRecipeEditor.Client;

internal struct Constants
{
    internal struct Path
    {
        internal static string Root => AppDomain.CurrentDomain.BaseDirectory;
    }

    internal struct File
    {
        internal static string ProjectFilter => "MCRecipeEditor Project (*.mcu)|*.mcu";
    }

    internal struct Colors
    {
        internal static SolidColorBrush Idle => FindColorBrush(nameof(Idle));
        internal static SolidColorBrush Execute => FindColorBrush(nameof(Execute));
        internal static SolidColorBrush Warning => FindColorBrush(nameof(Warning));
        internal static SolidColorBrush Error => FindColorBrush(nameof(Error));
        internal static SolidColorBrush Ready => FindColorBrush(nameof(Ready));
        internal static SolidColorBrush Rainbow => FindColorBrush(nameof(Rainbow));

        private static SolidColorBrush FindColorBrush(string name)
        {
            const string COLOR_BRUSH_BASE = "{0}StateColorBrush";

            var color = COLOR_BRUSH_BASE.Format(name);

            return (SolidColorBrush)App.Current.FindResource(color);
        }
    }

    internal struct Styles
    {
        internal static Style StandardContextMenuButtonStyle => (Style)App.Current.FindResource(nameof(StandardContextMenuButtonStyle));
        internal static Style ExtendedSeparatorStyle => (Style)App.Current.FindResource(nameof(ExtendedSeparatorStyle));
    }

    internal struct AppResources
    {
        internal static string TopContextMenu => Resources.TopContextMenu;
        internal static string BottomContextMenu => Resources.BottomContextMenu;
    }
}
