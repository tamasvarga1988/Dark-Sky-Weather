using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class DailyWeather
    {
        public string Icon { get; set; }
        public string Summary { get; set; }
        public decimal Temperature { get; set; }
        public decimal ApparentTemperature { get; set; }
        public decimal Pressure { get; set; }
        public decimal WindSpeed { get; set; }
        public decimal Humidity { get; set; }
        public decimal UVIndex { get; set; }
    }
}
