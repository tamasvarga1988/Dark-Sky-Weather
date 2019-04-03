using Newtonsoft.Json;

namespace DarkSkyWeather.Services.ApiModel
{
    public class ForecastResult
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }
        [JsonProperty("longitude")]
        public double Longitude { get; set; }
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
        [JsonProperty("currently")]
        public CurrentWeather CurrentWeather { get; set; }
        [JsonProperty("daily")]
        public DailyData DailyData { get; set; }
    }
}
