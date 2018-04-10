using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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


namespace CrashStats
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myStats = await OpenStatsProxy.GetStats("honda", "civic", "2000");

            ResultTextBlock.Text = "Model: " + myStats.Results[0].Model;
        }

        private void YearFly(object sender, RoutedEventArgs e)
        {
            YearTextBlock.Text = "Year";
        }

        private void MakeFly(object sender, RoutedEventArgs e)
        {
            MakeTextBlock.Text = "Make";
        }

        private void ModelFly(object sender, RoutedEventArgs e)
        {
            ModelTextBlock.Text = "Model";
        }

    }
}