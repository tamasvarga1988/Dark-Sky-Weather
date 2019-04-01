using System;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class DailyWeather : WeatherBase
    {
        public double TemperatureMin { get; set; }
        public DateTime TemperatureMinTime { get; set; }
        public double TemperatureMax { get; set; }
        public DateTime TemperatureMaxTime { get; set; }

        public DateTime ApparentTemperatureMinTime { get; set; }
        public double ApparentTemperatureMax { get; set; }
        public DateTime ApparentTemperatureMaxTime { get; set; }
        public double ApparentTemperatureMin { get; set; }
        
        public double UV { get; set; }
        public DateTime UVTime { get; set; }
    }
}
