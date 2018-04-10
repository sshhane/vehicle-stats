using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

using System.Diagnostics;


namespace VehicleStats
{
    /// <summary>
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    RootObject myStats = await OpenStatsProxy.GetStatsAsync("honda", "civic", "2000");

        //    ResultTextBlock.Text = "Model";
        //     ResultTextBlock.Text = "Model: " + myStats.result.Model; //crashes

        //}

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            RootObject myWeather = await OpenStatsProxy.GetWeather(20.0, 30.0);

            Debug.WriteLine("test: " + myWeather);

            //ResultTextBlock.Text = myWeather.name + " - " + ((int)myWeather.main.temp).ToString() + " - " + myWeather.weather[0].description;
        }
    }
}
