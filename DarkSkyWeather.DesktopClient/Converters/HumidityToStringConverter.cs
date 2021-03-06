﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace DarkSkyWeather.DesktopClient.Converters
{
    public class HumidityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var humidity = (double)value;
            return $"{humidity * 100}%";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
