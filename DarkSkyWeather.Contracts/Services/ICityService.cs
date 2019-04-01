using DarkSkyWeather.Contracts.DataModel;
using System.Collections.Generic;

namespace DarkSkyWeather.Contracts.Services
{
    public interface ICityService
    {
        List<City> GetCities();
    }
}