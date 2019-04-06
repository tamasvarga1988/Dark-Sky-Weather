using System;

namespace DarkSkyWeather.Contracts.Dtos
{
    public class DailyWeather : WeatherBase
    {
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        
        public double ApparentTemperatureMax { get; set; }
        public double ApparentTemperatureMin { get; set; }
        
        public double UV { get; set; }
    }
}
