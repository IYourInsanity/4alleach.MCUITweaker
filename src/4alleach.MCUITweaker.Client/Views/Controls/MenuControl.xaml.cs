using _4alleach.MCRecipeEditor.Client.UIExtension.UserControl;
using _4alleach.MCRecipeEditor.Client.ViewModels.Controls;
using System.Windows.Controls;

namespace _4alleach.MCRecipeEditor.Client.Views.Controls;

public partial class MenuControl : ExtendedControl
{
    public MenuControl() : base(typeof(MenuControlViewModel), nameof(MenuControl))
    {
        InitializeComponent();
    }

    private void GridMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if(e.ClickCount > 1)
        {
            if (sender is Grid grid)
            {
                var textBox = grid.Children[0] as TextBox;

                if (textBox != null)
                {
                    textBox.IsHitTestVisible = true;
                }
            }
        }
    }

    private void TextBoxLostFocus(object sender, System.Windows.RoutedEventArgs e)
    {
        DisableTextBox(sender);
    }

    private void TextBoxKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if(e.Key == System.Windows.Input.Key.Enter)
        {
            DisableTextBox(sender);
        }
    }

    private static void DisableTextBox(object sender)
    {
        if (sender is TextBox textBox)
        {
            textBox.IsHitTestVisible = false;
        }
    }
}
