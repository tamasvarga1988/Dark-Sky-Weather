using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Services.ApiModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services.Wrappers
{
    public class DarkSkyApiWrapper : IDarkSkyApiWrapper
    {
        public async Task<ForecastResult> GetForecast(ForecastRequest request)
        {
            var url = ForecastUrlBuilder.GetUrl(request);

            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(url);

            var forecast = JsonConvert.DeserializeObject<ForecastResult>(result);
            return forecast;
        }
    }
}
