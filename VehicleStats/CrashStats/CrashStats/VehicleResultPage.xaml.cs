using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CrashStats
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VehicleResultPage : Page
    {
        private string vehicleId;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.vehicleId = e.Parameter.ToString();

            // this.vehicleId = (string)e.Parameter;
            // this.vehicleId = e.ToString();

        }

        public VehicleResultPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string url = "4873";
            string make = "";

            VehicleRootObject results = await VehicleResult.GetVehicleResult(url);
            TxtBoxResult.Text = results.Results[0].Model;
        }
    }
}
