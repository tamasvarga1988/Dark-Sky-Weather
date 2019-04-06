using System.Windows;
using System.Windows.Controls;

namespace DarkSkyWeather.DesktopClient.UserControls
{
    /// <summary>
    /// Interaction logic for UvIndexMeter.xaml
    /// </summary>
    public partial class UvIndexMeter : UserControl
    {
        public UvIndexMeter()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty UvIndexProperty =
            DependencyProperty.Register("UvIndex", typeof(double), typeof(UvIndexMeter));

        public double UvIndex
        {
            get { return (double)GetValue(UvIndexProperty); }
            set { SetValue(UvIndexProperty, value); }
        }
    }
}
