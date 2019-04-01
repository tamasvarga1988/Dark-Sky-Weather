using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class CurrentWeather : WeatherBase
    {
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double UV { get; set; }
    }
}
