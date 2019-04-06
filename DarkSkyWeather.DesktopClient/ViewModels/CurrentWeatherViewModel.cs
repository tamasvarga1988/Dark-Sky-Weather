using DarkSkyWeather.Contracts.Dtos;
using Prism.Mvvm;

namespace DarkSkyWeather.DesktopClient.ViewModels
{
    public class CurrentWeatherViewModel : BindableBase
    {
        private CurrentWeather currentWeather;
        public CurrentWeather CurrentWeather
        {
            get { return currentWeather; }
            set { SetProperty(ref currentWeather, value); }
        }
        
        private Language selectedLanguage;
        public Language SelectedLanguage
        {
            get { return selectedLanguage; }
            set { SetProperty(ref selectedLanguage, value); }
        }
    }
}
