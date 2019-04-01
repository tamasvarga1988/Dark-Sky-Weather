using DarkSkyWeather.Contracts.DataModel;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DarkSkyWeather.Services.Wrappers
{
    internal static class ForecastUrlBuilder
    {
        private const string ApiUrl = "https://api.darksky.net/forecast";
        private const string ApiKey = "27f73a97cc2deeaa004569a06af1e043";

        internal static string GetUrl(ForecastRequest request)
        {
            var latitudeString = request.Latitude.ToString(CultureInfo.InvariantCulture);
            var longitudeString = request.Longitude.ToString(CultureInfo.InvariantCulture);

            var excludeBlocks = GetExcludeBlocks(request.Blocks);
            var units = request.Units.GetDescription();

            var builder = new StringBuilder();
            builder.Append($"{ApiUrl}/{ApiKey}/{latitudeString},{longitudeString}");
            builder.Append($"?exlude=[{excludeBlocks}]");
            builder.Append($"&lang={request.Language}");
            builder.Append($"&units={units}");

            return builder.ToString();
        }

        private static string GetExcludeBlocks(ForecastBlocks blocks)
        {
            var values = Enum.GetValues(typeof(ForecastBlocks));
            var exludedBlocks = new List<string>();

            foreach (var value in values)
            {
                var block = (ForecastBlocks)value;

                if (!blocks.HasFlag(block))
                {
                    exludedBlocks.Add(block.GetDescription());
                }
            }

            return string.Join(",", exludedBlocks);
        }
    }
}
