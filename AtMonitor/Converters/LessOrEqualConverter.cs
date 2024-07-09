using System.Globalization;
using Windows.Services.TargetedContent;

namespace AtMonitor.Views
{
    internal class LessOrEqualConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                if (targetType == typeof(bool))
                {
                    return (int)value <= (int)parameter;
                }
                else if (targetType == typeof(Color))
                {
                    return (int)value >= (int)parameter
                        ? Colors.IndianRed
                        : Colors.Black;
                }
            }
            throw new NotImplementedException();
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
