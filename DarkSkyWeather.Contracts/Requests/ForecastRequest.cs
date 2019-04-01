using DarkSkyWeather.Contracts.DataModel;

namespace DarkSkyWeather.Contracts.Requests
{
    public class ForecastRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ForecastBlocks Blocks { get; set; }
        public string Language { get; set; }
    }
}
