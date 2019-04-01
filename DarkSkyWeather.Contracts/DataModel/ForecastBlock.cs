using System;

namespace DarkSkyWeather.Contracts.DataModel
{
    [Flags]
    public enum ForecastBlocks
    {
        Currently = 1,
        Minutely = 2,
        Hourly = 4,
        Daily = 8,
        Alerts = 16,
        Flags = 32
    }
}