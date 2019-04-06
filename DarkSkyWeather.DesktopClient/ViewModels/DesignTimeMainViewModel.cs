using DarkSkyWeather.Contracts.Dtos;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DarkSkyWeather.DesktopClient.ViewModels
{
    public class DesignTimeMainViewModel : BindableBase
    {
        public ObservableCollection<City> Cities { get; private set; }
        public ObservableCollection<Language> Languages { get; private set; }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value); }
        }

        private Language selectedLanguage;
        public Language SelectedLanguage
        {
            get { return selectedLanguage; }
            set { SetProperty(ref selectedLanguage, value); }
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
            Cities = new ObservableCollection<City>
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

            Languages = new ObservableCollection<Language>
            {
                new Language{ Code = "en", LanguageCountryCode = "en-US", Name = "English", Icon = "us" },
                new Language{ Code = "hu", LanguageCountryCode = "hu-HU", Name = "Magyar", Icon = "hu" }
            };

            SelectedCity = Cities.First();
            SelectedLanguage = Languages.First();

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
                    Icon = "clear-day",                    
                },
                DailyForecast = new List<DailyWeather>
                {
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(1),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 1,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(2),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 2,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(3),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 4,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(4),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 6,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(5),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 7.5,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(6),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 9,
                        Icon = "clear-day",
                    },
                    new DailyWeather
                    {
                        Summary = "Foltokban felhős",
                        Date = DateTime.Now.AddDays(7),
                        TemperatureMin = 17.2,
                        TemperatureMax = 17.2,
                        ApparentTemperatureMin = 16,
                        ApparentTemperatureMax = 16,
                        Humidity = 0.30,
                        WindSpeed = 18.4,
                        Pressure = 1013,
                        UV = 14,
                        Icon = "clear-day",
                    },
                }
            };
        }
    }
}
