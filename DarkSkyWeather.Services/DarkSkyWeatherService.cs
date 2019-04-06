using DarkSkyWeather.Contracts.Dtos;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.Services.Mapping;
using DarkSkyWeather.Services.Repositories;
using DarkSkyWeather.Services.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services
{
    public class DarkSkyWeatherService : IWeatherService
    {
        private readonly IDarkSkyApiWrapper darkSkyApiWrapper;
        private readonly ILanguageRepository languageRepository;

        public DarkSkyWeatherService(IDarkSkyApiWrapper darkSkyApiWrapper, ILanguageRepository languageRepository)
        {
            this.darkSkyApiWrapper = darkSkyApiWrapper ?? throw new ArgumentNullException(nameof(darkSkyApiWrapper));
            this.languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
        }

        public async Task<Forecast> GetForecast(ForecastRequest request)
        {
            ValidateForecastRequest(request);

            var apiForecast = await darkSkyApiWrapper.GetForecast(request);

            // API returns 8 days (first day is today), but we need only the next 7 days
            apiForecast.DailyData.Days = apiForecast.DailyData.Days.Skip(1).ToList();
            
            var forecast = MapperConfig.ForecastResultMapper.Map<Forecast>(apiForecast);
            return forecast;
        }

        public async Task<List<Language>> GetLanguages()
        {
            return await languageRepository.GetLanguages();
        }

        private void ValidateForecastRequest(ForecastRequest request)
        {
            if (string.IsNullOrEmpty(request.Language))
            {
                throw new ArgumentNullException(nameof(request.Language), "Language must be specified.");
            }

            if (request.Latitude < -90 || request.Latitude > 90)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Latitude), "Latitude value must be between -90 and 90.");
            }

            if (request.Longitude < -180 || request.Longitude > 180)
            {
                throw new ArgumentOutOfRangeException(nameof(request.Longitude), "Longitude value must be between -180 and 180.");
            }
        }
    }
}