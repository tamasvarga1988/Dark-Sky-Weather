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

        public DarkSkyWeatherService(IDarkSkyApiWrapper darkSkyApiWrapper)
        {
            this.darkSkyApiWrapper = darkSkyApiWrapper;
        }

        public async Task<Forecast> GetForecast(ForecastRequest request)
        {
            var apiForecast = await darkSkyApiWrapper.GetForecast(request);
            
            var forecast = MapperConfig.ForecastResultMapper.Map<Forecast>(apiForecast);
            return forecast;
        }
    }
}