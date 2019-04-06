using DarkSkyWeather.Contracts.Dtos;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Services.ApiModel;
using DarkSkyWeather.Services.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace DarkSkyWeather.Services.Wrappers
{
    public class DarkSkyApiWrapper : IDarkSkyApiWrapper
    {
        // this should be stored somewhere safe
        private const string ApiKey = "27f73a97cc2deeaa004569a06af1e043";
        private readonly string ApiUrl;

        public DarkSkyApiWrapper()
        {
            ApiUrl = ConfigurationManager.AppSettings["WeatherApiUrl"];
        }

        public async Task<ForecastResult> GetForecast(ForecastRequest request)
        {
            var url = GetForecastUrl(request);
            ForecastResult forecastResult;

            using (var httpClient = new HttpClient())
            {
                var result = await httpClient.GetStringAsync(url);
                forecastResult = JsonConvert.DeserializeObject<ForecastResult>(result);
            }

            return forecastResult;
        }
        
        private string GetForecastUrl(ForecastRequest request)
        {
            var latitudeString = request.Latitude.ToString(CultureInfo.InvariantCulture);
            var longitudeString = request.Longitude.ToString(CultureInfo.InvariantCulture);

            var excludeBlocks = GetExcludeBlocks(request.Blocks);
            var units = request.Units.GetDescription();

            var query = HttpUtility.ParseQueryString(string.Empty);
            query["exlude"] = excludeBlocks;
            query["lang"] = request.Language;
            query["units"] = units;
            string queryString = query.ToString();

            var url = $"{ApiUrl}/{ApiKey}/{latitudeString},{longitudeString}?{queryString}";

            return url;
        }

        private string GetExcludeBlocks(ForecastBlocks blocks)
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
