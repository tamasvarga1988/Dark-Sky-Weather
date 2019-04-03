using DarkSkyWeather.Contracts.DataModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.DesktopClient.ViewModel
{
    public class DesignTimeMainViewModel : BindableBase
    {
        public List<City> Cities { get; private set; }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value); }
        }

        private Forecast forecast;
        public Forecast Forecast
        {
            get { return forecast; }
            set { SetProperty(ref forecast, value); }
        }

        public DesignTimeMainViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            Cities = new List<City>
            {
                new City { Name = "Budapest", Latitude = 47.497913, Longitude = 19.040236 },
                new City { Name = "Luxembourg", Latitude = 49.815273, Longitude = 6.129583 },
                new City { Name = "Debrecen", Latitude = 47.533340, Longitude = 21.625210 },
                new City { Name = "Pécs", Latitude = 46.071301, Longitude = 18.233141 },
                new City { Name = "Wienna", Latitude = 48.209209, Longitude = 16.372780 },
                new City { Name = "Prague", Latitude = 50.075539, Longitude = 14.437800 },
                new City { Name = "München", Latitude = 48.135124, Longitude = 11.581981 },
                new City { Name = "Amsterdam", Latitude = 52.370216, Longitude = 4.895168 },
            };

            SelectedCity = Cities.First();

            Forecast = new Forecast
            {
                Current = new CurrentWeather
                {
                    Summary = "Foltokban felhős",
                    Date = DateTime.Now,
                    Temperature = 17.2,
                    ApparentTemperature = 16,
                    Humidity = 0.30,
                    WindSpeed = 18.4,
                    Pressure = 1013,
                    UV = 3.5,
                    Icon = "partly-cloudy"
                }
            };
        }
    }
}
