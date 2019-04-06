using System.ComponentModel;

namespace DarkSkyWeather.Contracts.Dtos
{
    public enum ForecastUnits
    {
        [Description("auto")]
        Auto,
        [Description("ca")]
        CA,
        [Description("uk2")]
        UK,
        [Description("us")]
        US,
        [Description("si")]
        SI
    }
}
