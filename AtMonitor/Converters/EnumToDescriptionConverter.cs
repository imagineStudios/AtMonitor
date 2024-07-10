using System.ComponentModel;
using System.Globalization;

namespace AtMonitor.Views;

internal class EnumToDescriptionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => (value as Enum)?.GetAttributeOfType<DescriptionAttribute>()?.Description;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
