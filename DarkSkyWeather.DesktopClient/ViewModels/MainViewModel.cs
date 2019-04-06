using DarkSkyWeather.Contracts.Dtos;
using DarkSkyWeather.Contracts.Requests;
using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.DesktopClient.TaskCompletion;
using DarkSkyWeather.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSkyWeather.DesktopClient.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IWeatherService weatherService;
        private readonly ICityService cityService;

        private NotifyTaskCompletionBase<List<City>> citiesTaskCompletion { get; set; }
        private NotifyTaskCompletionBase<List<Language>> languagesTaskCompletion { get; set; }
        private NotifyTaskCompletionBase<Forecast> forecastTaskCompletion { get; set; }

        public ObservableCollection<City> Cities { get; private set; }
        public ObservableCollection<Language> Languages { get; private set; }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value, () => { LoadForecast(); }); }
        }

        private Language selectedLanguage;
        public Language SelectedLanguage
        {
            get { return selectedLanguage; }
            set
            {
                SetProperty(ref selectedLanguage, value, () =>
                {
                    CurrentWeatherViewModel.SelectedLanguage = selectedLanguage;
                    LoadForecast();
                });
            }
        }

        private Forecast forecast;
        public Forecast Forecast
        {
            get { return forecast; }
            private set { SetProperty(ref forecast, value); }
        }

        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                SetProperty(ref isLoading, value, () =>
                {
                    if (isLoading)
                    {
                        ErrorMessage = null;
                    }
                    RefreshCommand.RaiseCanExecuteChanged();
                });
            }
        }

        public DelegateCommand RefreshCommand { get; private set; }

        private CurrentWeatherViewModel currentWeatherViewModel;
        public CurrentWeatherViewModel CurrentWeatherViewModel
        {
            get { return currentWeatherViewModel; }
            set { SetProperty(ref currentWeatherViewModel, value); }
        }
        
        public MainViewModel(
            IWeatherService weatherService,
            ICityService cityService,
            NotifyTaskCompletionBase<List<City>> citiesTaskCompletion,
            NotifyTaskCompletionBase<List<Language>> languagesTaskCompletion,
            NotifyTaskCompletionBase<Forecast> forecastTaskCompletion)
        {
            this.weatherService = weatherService;
            this.cityService = cityService;

            this.forecastTaskCompletion = forecastTaskCompletion ?? throw new ArgumentNullException(nameof(forecastTaskCompletion));
            this.citiesTaskCompletion = citiesTaskCompletion ?? throw new ArgumentNullException(nameof(citiesTaskCompletion));
            this.languagesTaskCompletion = languagesTaskCompletion ?? throw new ArgumentNullException(nameof(languagesTaskCompletion));

            Initialize();
        }


        private void Initialize()
        {
            citiesTaskCompletion.TaskCompleted += CitiesLoaded;
            languagesTaskCompletion.TaskCompleted += LanguagesLoaded;
            forecastTaskCompletion.TaskCompleted += ForecastLoaded;

            citiesTaskCompletion.OnError += OnError;
            languagesTaskCompletion.OnError += OnError;
            forecastTaskCompletion.OnError += OnError;

            RefreshCommand = new DelegateCommand(Refresh, CanRefresh);

            CurrentWeatherViewModel = new CurrentWeatherViewModel();

            LoadCities();
            LoadLanguages();
        }

        private void Refresh()
        {
            LoadForecast();
        }

        private bool CanRefresh()
        {
            return !IsLoading;
        }

        private void LoadCities()
        {
            IsLoading = true;
            citiesTaskCompletion.Execute(cityService.GetCities());
        }

        private void CitiesLoaded(List<City> cities)
        {
            IsLoading = false;
            Cities = new ObservableCollection<City>();
            Cities.AddRange(cities);

            if (Cities != null && Cities.Count > 0)
            {
                SelectedCity = Cities.First();
            }
        }

        private void LoadLanguages()
        {
            IsLoading = true;
            languagesTaskCompletion.Execute(weatherService.GetLanguages());
        }

        private void LanguagesLoaded(List<Language> languages)
        {
            IsLoading = false;
            Languages = new ObservableCollection<Language>();
            Languages.AddRange(languages);

            if (Languages != null && Languages.Count > 0)
            {
                SelectedLanguage = Languages.First();
            }
        }

        private void LoadForecast()
        {
            IsLoading = true;
            if (SelectedCity == null)
            {
                return;
            }
            if (SelectedLanguage == null)
            {
                return;
            }

            forecastTaskCompletion.Execute(
                weatherService.GetForecast(new ForecastRequest
                {
                    Latitude = SelectedCity.Latitude,
                    Longitude = SelectedCity.Longitude,
                    Blocks = ForecastBlocks.Currently | ForecastBlocks.Daily,
                    Language = SelectedLanguage.Code,
                    Units = ForecastUnits.SI
                }));
        }

        private void ForecastLoaded(Forecast forecast)
        {
            IsLoading = false;
            Forecast = forecast;

            CurrentWeatherViewModel.CurrentWeather = Forecast.Current;
        }

        private void OnError(Exception exception)
        {
            IsLoading = false;
            // exception details could be logged here

            string message = $"An error occured while downloading data. {exception?.Message}";
            ErrorMessage = message;
        }
    }
}