using System;

namespace DarkSkyWeather.Contracts.DataModel
{
    public abstract class WeatherBase
    {
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        public string Summary { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }        
    }
}
