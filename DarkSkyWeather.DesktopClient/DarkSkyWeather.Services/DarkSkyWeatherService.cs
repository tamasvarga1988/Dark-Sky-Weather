using AutoMapper;
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
        public async Task<Forecast> GetForecast(ForecastRequest request)
        {
            var wrapper = new DarkSkyApiWrapper();
            var apiForecast = await wrapper.GetForecast(request);
            
            var forecast = MapperConfig.ForecastResultMapper.Map<Forecast>(apiForecast);

            return new Forecast();
        }
    }
}