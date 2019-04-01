using Newtonsoft.Json;

namespace DarkSkyWeather.Services.ApiModel
{
    public class CurrentWeather
    {
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }
        [JsonProperty("temperature")]
        public double Temperature { get; set; }
        [JsonProperty("apparentTemperature")]
        public double ApparentTemperature { get; set; }
        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }
        [JsonProperty("uvIndex")]
        public int UV { get; set; }
    }
}
