using DarkSkyWeather.Contracts.Dtos;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class DateToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
            {
                return null;
            }

            var date = (DateTime)values[0];
            var language = (Language)values[1];
            var stringFormat = parameter.ToString();

            return date.ToString(stringFormat, CultureInfo.GetCultureInfo(language.LanguageCountryCode));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
