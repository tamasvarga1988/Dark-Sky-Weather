using DarkSkyWeather.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private async Task Init()
        {
            var weatherService = new DarkSkyWeatherService();
            await weatherService.GetWeatherInfo(new Contracts.Requests.ForecastRequest
            {
                Latitude = 47.497913,
                Longitude = 19.040236
            });
        }
    }
}
