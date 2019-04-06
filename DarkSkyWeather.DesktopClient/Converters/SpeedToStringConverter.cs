using System;
using System.Globalization;
using System.Windows.Data;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class SpeedToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} km/h";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
