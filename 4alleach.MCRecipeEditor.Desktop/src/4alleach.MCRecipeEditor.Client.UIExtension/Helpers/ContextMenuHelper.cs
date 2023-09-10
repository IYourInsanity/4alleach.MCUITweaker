using System.Windows;

namespace _4alleach.MCRecipeEditor.Client.UIExtension.Helpers;
public static class ContextMenuHelper
{
    public static readonly DependencyProperty IdentifierProperty = DependencyProperty.RegisterAttached(
        "Identifier",
        typeof(string),
        typeof(ContextMenuHelper),
        new FrameworkPropertyMetadata(string.Empty, OnIdentifierChanged));

    private static void OnIdentifierChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

    public static string GetIdentifier(DependencyObject dp)
    {
        return (string)dp.GetValue(IdentifierProperty);
    }

    public static void SetIdentifier(DependencyObject dp, string value)
    {
        dp.SetValue(IdentifierProperty, value);
    }
}
