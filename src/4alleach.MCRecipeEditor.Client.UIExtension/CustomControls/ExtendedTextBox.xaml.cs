using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.CustomControls;

public partial class ExtendedTextBox : System.Windows.Controls.UserControl
{
    public static readonly DependencyProperty TextSourceProperty = DependencyProperty.Register(
                                                                                  nameof(TextSource),
                                                                                  typeof(string),
                                                                                  typeof(ExtendedTextBox),
                                                                                  new FrameworkPropertyMetadata(
                                                                                      string.Empty,
                                                                                      FrameworkPropertyMetadataOptions.AffectsRender));

    public string TextSource
    {
        get => (string)GetValue(TextSourceProperty);
        set => SetValue(TextSourceProperty, value);
    }

    public ExtendedTextBox()
    {
        InitializeComponent();

        DataContext = this;
    }

    private void Label_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        TextBoxControl.Visibility = Visibility.Visible;
        LabelControl.Visibility = Visibility.Hidden;
    }

    private void TextBoxControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if(e.Key == System.Windows.Input.Key.Enter)
        {
            TextBoxControl.Visibility = Visibility.Hidden;
            LabelControl.Visibility = Visibility.Visible;
        }
    }
}
