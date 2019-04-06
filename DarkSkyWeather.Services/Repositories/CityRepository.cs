using System.Collections.Generic;
using System.Threading.Tasks;
using DarkSkyWeather.Contracts.Dtos;

namespace DarkSkyWeather.Services.Repositories
{
    public class CityRepository : ICityRepository
    {
        private List<City> cities;

        public Task<List<City>> GetCities()
        {
            if (cities == null)
            {
                InitializeCities();
            }

            return Task.FromResult(cities);
        }

        private void InitializeCities()
        {
            // Latitude and Longitude data: https://www.latlong.net/
            cities = new List<City>
            {
                new City { Name = "Budapest", Latitude = 47.497913, Longitude = 19.040236 },
                new City { Name = "Luxembourg", Latitude = 49.815273, Longitude = 6.129583 },
                new City { Name = "Debrecen", Latitude = 47.533340, Longitude = 21.625210 },
                new City { Name = "Pécs", Latitude = 46.071301, Longitude = 18.233141 },
                new City { Name = "Wienna", Latitude = 48.209209, Longitude = 16.372780 },
                new City { Name = "Prague", Latitude = 50.075539, Longitude = 14.437800 },
                new City { Name = "München", Latitude = 48.135124, Longitude = 11.581981 },
                new City { Name = "Amsterdam", Latitude = 52.370216, Longitude = 4.895168 },
                new City { Name = "New York", Latitude = 40.712776, Longitude = -74.005974 },
            };
        }
    }
}
