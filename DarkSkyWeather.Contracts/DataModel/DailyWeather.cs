using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.DataModel
{
    public class DailyWeather
    {
        public DateTime Date { get; set; }
        public string Icon { get; set; }
        public string Summary { get; set; }
        public double Temperature { get; set; }
        public double ApparentTemperature { get; set; }
        public double Pressure { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double UVIndex { get; set; }
    }
}
