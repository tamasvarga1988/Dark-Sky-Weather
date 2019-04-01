using DarkSkyWeather.Contracts.DataModel;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services
{
    public class DarkSkyWeatherService : IWeatherService
    {
        public async Task<WeatherInfo> GetWeatherInfo(ForecastRequest request)
        {
            var wrapper = new DarkSkyApiWrapper();
            var forecast = await wrapper.GetForecast(request);

            return new WeatherInfo();
        }
    }
}