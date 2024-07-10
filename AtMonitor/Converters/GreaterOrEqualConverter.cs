using System.Globalization;

namespace AtMonitor.Views;

internal class GreaterOrEqualConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null && parameter != null)
        {
            if (targetType == typeof(bool))
            {
                return (int)value >= (int)parameter;
            }
        }
        throw new NotImplementedException();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
