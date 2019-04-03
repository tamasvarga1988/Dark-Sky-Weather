using Newtonsoft.Json;
using System.Collections.Generic;

namespace DarkSkyWeather.Services.ApiModel
{
    public class DailyData
    {
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("data")]
        public List<DailyWeather> Days { get; set; }
    }
}
