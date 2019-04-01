using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Services.ApiModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.Wrappers
{
    internal class DarkSkyApiWrapper
    {
        private const string ApiUrl = "https://api.darksky.net/forecast";
        private const string ApiKey = "27f73a97cc2deeaa004569a06af1e043";

        internal async Task<ForecastResult> GetForecast(ForecastRequest request)
        {
            var latitudeString = request.Latitude.ToString(CultureInfo.InvariantCulture);
            var longitudeString = request.Longitude.ToString(CultureInfo.InvariantCulture);

            var url = $"{ApiUrl}/{ApiKey}/{latitudeString},{longitudeString}";

            HttpClient client = new HttpClient();

            var result = await client.GetStringAsync(url);

            var forecast = JsonConvert.DeserializeObject<ForecastResult>(result);

            return forecast;
        }
    }
}
