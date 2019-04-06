using System;
using System.Globalization;
using System.Windows.Data;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class CountryFlagImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Images/CountryFlags/{value}.jpg";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
