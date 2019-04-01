namespace DarkSkyWeather.Contracts.DataModel
{
    public class DailyWeather : WeatherBase
    {
        public double TemperatureMin { get; set; }
        public double TemperatureMinTime { get; set; }
        public double TemperatureMax { get; set; }
        public double TemperatureMaxTime { get; set; }

        public double ApparentTemperatureMinTime { get; set; }
        public double ApparentTemperatureMax { get; set; }
        public double ApparentTemperatureMaxTime { get; set; }
        public double ApparentTemperatureMin { get; set; }
        
        public double UV { get; set; }
        public double UVTime { get; set; }
    }
}
