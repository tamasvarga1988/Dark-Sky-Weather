using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class UvToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var uvIndex = (double)value;

            if (uvIndex < 3)
            {
                return new SolidColorBrush(Colors.Green);
            }
            else if (uvIndex < 6)
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else if (uvIndex < 8)
            {
                return new SolidColorBrush(Colors.Orange);
            }
            else if (uvIndex < 11)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Blue);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
