using System;
using System.Globalization;
using System.Windows.Data;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString("dddd HH:mm", CultureInfo.GetCultureInfo("hu"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
