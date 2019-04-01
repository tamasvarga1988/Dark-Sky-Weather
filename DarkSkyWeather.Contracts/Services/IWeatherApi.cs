using DarkSkyWeather.Contracts.DataModel;
using DarkSkyWeather.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Contracts.Services
{
    public interface IWeatherService
    {
        Task<Forecast> GetForecast(ForecastRequest request);
    }
}
