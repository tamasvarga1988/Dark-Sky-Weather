using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class WeatherInfo
    {
        public DailyWeather Current { get; set; }

        public List<DailyWeather> Forecast { get; set; }
    }
}
