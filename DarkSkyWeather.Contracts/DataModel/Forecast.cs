using System.Collections.Generic;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class Forecast
    {
        public string TimeZone { get; set; }

        public CurrentWeather Current { get; set; }

        public List<DailyWeather> DailyForecast { get; set; }
    }
}
