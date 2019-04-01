using DarkSkyWeather.Services;
using System.Threading.Tasks;
using System.Windows;

namespace DarkSkyWeather.DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        // TODO Clean code behind file
        
        private async Task Init()
        {            
            var weatherService = new DarkSkyWeatherService();
            await weatherService.GetForecast(new Contracts.Requests.ForecastRequest
            {
                Latitude = 47.497913,
                Longitude = 19.040236,
                Blocks = Contracts.DataModel.ForecastBlocks.Currently | Contracts.DataModel.ForecastBlocks.Daily,
                Language = "hu",
                Units = Contracts.DataModel.ForecastUnits.SI
            });
        }
    }
}
