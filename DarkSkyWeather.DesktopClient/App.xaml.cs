using DarkSkyWeather.Contracts.Services;
using DarkSkyWeather.DesktopClient.TaskCompletion;
using DarkSkyWeather.DesktopClient.ViewModels;
using DarkSkyWeather.Services;
using DarkSkyWeather.Services.Repositories;
using DarkSkyWeather.Services.Wrappers;
using Prism.Mvvm;
using System.Windows;
using Unity;

namespace DarkSkyWeather.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IUnityContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SetupUnityContainer();
            SetupViewModelLocator();
        }

        private void SetupUnityContainer()
        {
            container = new UnityContainer();

            container.RegisterType(typeof(ILanguageRepository), typeof(LanguageRepository));
            container.RegisterType(typeof(ICityRepository), typeof(CityRepository));
            container.RegisterType(typeof(IDarkSkyApiWrapper), typeof(DarkSkyApiWrapper));
            container.RegisterType(typeof(IWeatherService), typeof(DarkSkyWeatherService));
            container.RegisterType(typeof(ICityService), typeof(CityService));
            container.RegisterInstance(Services.Mapping.MapperConfig.CreateMapper());
            container.RegisterType(typeof(NotifyTaskCompletionBase<>), typeof(NotifyTaskCompletion<>));
        }

        private void SetupViewModelLocator()
        {
            ViewModelLocationProvider.Register(typeof(DesktopClient.MainWindow).ToString(), typeof(MainViewModel));

            ViewModelLocationProvider.SetDefaultViewModelFactory((type) =>
            {
                return container.Resolve(type);
            });
        }
    }
}
