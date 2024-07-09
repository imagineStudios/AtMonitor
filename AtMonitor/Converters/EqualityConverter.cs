using System.Globalization;

namespace AtMonitor.Views
{
    internal class EqualityConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (targetType == typeof(bool))
            {
                return value?.Equals(parameter) ?? false;
            }
            throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
