using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace _4alleach.MCRecipeEditor.Client.Converters;

public sealed class BooleanToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null)
            return Visibility.Collapsed;

        if ((bool)value == true)
        {
            return Visibility.Visible;
        }
        else
        {
            return Visibility.Hidden;
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
