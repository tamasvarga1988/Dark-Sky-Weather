using Newtonsoft.Json;

namespace DarkSkyWeather.Services.ApiModel
{
    public class DailyWeather
    {
        [JsonProperty("time")]
        public int Time { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }
        [JsonProperty("pressure")]
        public double Pressure { get; set; }
        [JsonProperty("windSpeed")]
        public double WindSpeed { get; set; }

        [JsonProperty("uvIndex")]
        public int UV { get; set; }
        [JsonProperty("uvIndexTime")]
        public int UVTime { get; set; }

        [JsonProperty("temperatureMin")]
        public double TemperatureMin { get; set; }
        [JsonProperty("temperatureMax")]
        public double TemperatureMax { get; set; }

        [JsonProperty("apparentTemperatureMin")]
        public double ApparentTemperatureMin { get; set; }
        [JsonProperty("apparentTemperatureMax")]
        public double ApparentTemperatureMax { get; set; }
    }
}
