using DarkSkyWeather.Contracts.DataModel;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.DesktopClient.Helpers;
using DarkSkyWeather.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.DesktopClient.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private readonly IWeatherService weatherService;
        private readonly ICityService cityService;

        private NotifyTaskCompletion<List<City>> citiesTaskCompletion;
        private NotifyTaskCompletion<Forecast> forecastTaskCompletion;

        public ObservableCollection<City> Cities { get; private set; }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                if (selectedCity != value)
                {
                    selectedCity = value;
                    RaisePropertyChanged();
                    LoadForecast();
                }
            }
        }

        private Forecast forecast;
        public Forecast Forecast
        {
            get { return forecast; }
            set
            {
                if (forecast != value)
                {
                    forecast = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        public MainViewModel(IWeatherService weatherService, ICityService cityService)
        {
            this.weatherService = weatherService;
            this.cityService = cityService;

            Initialize();
        }

        private void Initialize()
        {
            citiesTaskCompletion = new NotifyTaskCompletion<List<City>>(cityService.GetCities(), (cities) =>
                {
                    Cities = new ObservableCollection<City>();
                    Cities.AddRange(cities);
                    
                    if (Cities != null && Cities.Count > 0)
                    {
                        SelectedCity = Cities.First();
                    }
                });
        }

        private void ForecastTaskCompletionPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(forecastTaskCompletion.Result))
            {
                Forecast = forecastTaskCompletion.Result;
            }
        }

        private void LoadForecast()
        {
            if (SelectedCity == null)
            {
                return;
            }

            if (forecastTaskCompletion != null)
            {
                forecastTaskCompletion.PropertyChanged -= ForecastTaskCompletionPropertyChanged;
                forecastTaskCompletion = null;
            }

            forecastTaskCompletion = new NotifyTaskCompletion<Forecast>(
                weatherService.GetForecast(new ForecastRequest
                {
                    Latitude = SelectedCity.Latitude,
                    Longitude = SelectedCity.Longitude,
                    Blocks = ForecastBlocks.Currently | ForecastBlocks.Daily,
                    Language = "hu",
                    Units = ForecastUnits.SI
                }));
            forecastTaskCompletion.PropertyChanged += ForecastTaskCompletionPropertyChanged;
        }
    }
}