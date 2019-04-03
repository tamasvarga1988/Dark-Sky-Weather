using DarkSkyWeather.Contracts.DataModel;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.Services.Mapping;
using DarkSkyWeather.Services.Wrappers;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services
{
    public class DarkSkyWeatherService : IWeatherService
    {
        IDarkSkyApiWrapper darkSkyApiWrapper;

        public async Task<Forecast> GetForecast(ForecastRequest request)
        {
            // TODO Use DI
            darkSkyApiWrapper = new DarkSkyApiWrapper();

            var apiForecast = await darkSkyApiWrapper.GetForecast(request);
            
            var forecast = MapperConfig.ForecastResultMapper.Map<Forecast>(apiForecast);
            return forecast;
        }
    }
}