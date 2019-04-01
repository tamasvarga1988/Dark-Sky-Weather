using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.ApiModel
{
    public class ForecastResult
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timezone { get; set; }
        public CurrentWeather currently { get; set; }        
        public DailyData daily { get; set; }
    }
}
