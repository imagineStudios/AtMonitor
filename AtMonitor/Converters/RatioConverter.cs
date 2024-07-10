using System.Globalization;

namespace AtMonitor.Views;

internal class RatioConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return Math.Min(1.0, Math.Max(0.0, (int)(value ?? 0) / (double)(int)(parameter ?? 1.0)));
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
