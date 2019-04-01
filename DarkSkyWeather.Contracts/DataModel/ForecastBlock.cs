using System;
using System.ComponentModel;

namespace DarkSkyWeather.Contracts.DataModel
{
    [Flags]
    public enum ForecastBlocks
    {
        [Description("currently")]
        Currently = 1,
        [Description("minutely")]
        Minutely = 2,
        [Description("hourly")]
        Hourly = 4,
        [Description("daily")]
        Daily = 8,
        [Description("alerts")]
        Alerts = 16,
        [Description("flags")]
        Flags = 32
    }
}