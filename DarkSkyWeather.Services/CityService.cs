using DarkSkyWeather.Contracts.Dtos;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DarkSkyWeather.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
        }

        public async Task<List<City>> GetCities()
        {
            return await cityRepository.GetCities();
        }
    }
}
