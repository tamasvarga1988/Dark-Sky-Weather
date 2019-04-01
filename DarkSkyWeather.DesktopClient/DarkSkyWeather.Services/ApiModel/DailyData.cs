using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.ApiModel
{
    public class DailyData
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }
        public string icon { get; set; }
        public List<DailyWeather> data { get; set; }
    }
}
