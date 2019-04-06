using DarkSkyWeather.Contracts.Dtos;
using DarkSkyWeather.Contracts.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecast(ForecastRequest request);

        Task<List<Language>> GetLanguages();
    }
}
