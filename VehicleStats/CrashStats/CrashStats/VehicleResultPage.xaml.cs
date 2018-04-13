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
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.UI.Xaml.Media.Imaging;


namespace CrashStats
{

    public sealed partial class VehicleResultPage : Page
    {
        private string vehicleId;
        public int fcdrR, fcprR, scdrR, scprR, rollR;


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.vehicleId = e.Parameter.ToString();

        }

        public VehicleResultPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            VehicleRootObject results = await VehicleResult.GetVehicleResult(vehicleId);

            //string r = results.Results[0].FrontCrashDriversideRating;

            //convert to int
            Int32.TryParse(results.Results[0].FrontCrashDriversideRating, out fcdrR);
            Int32.TryParse(results.Results[0].FrontCrashPassengersideRating, out fcprR);
            Int32.TryParse(results.Results[0].SideCrashDriversideRating, out scdrR);
            Int32.TryParse(results.Results[0].SideCrashPassengersideRating, out scprR);
            Int32.TryParse(results.Results[0].RolloverRating2, out rollR);

            // set ratings ctx to data from api
            this.fcdrRating.DataContext = new RatingViewModel() { RatingValue = fcdrR };
            this.fcprRating.DataContext = new RatingViewModel() { RatingValue = fcprR };
            this.scdrRating.DataContext = new RatingViewModel() { RatingValue = scdrR };
            this.scprRating.DataContext = new RatingViewModel() { RatingValue = scprR };
            this.rollRating.DataContext = new RatingViewModel() { RatingValue = rollR };

            TxtBoxDesc.Text = results.Results[0].VehicleDescription;

            TxtBoxFcdr.Text = "Front crash driver side rating: ";
            TxtBoxFcpr.Text = "Front crash passenger side rating: ";
            TxtBoxScdr.Text = "Side crash driver side rating: ";
            TxtBoxScpr.Text = "Side crash passenger side rating: ";
            TxtBoxRoll.Text = "Rollover rating: ";
            TxtBoxComplaints.Text = "Complaints: " + results.Results[0].ComplaintsCount.ToString();
            if(results.Results[0].SideCrashPicture != null)
            {
                ImgCarCrash.Source = new BitmapImage(new Uri(results.Results[0].SideCrashPicture));
                Debug.WriteLine("in if");
            }
            else 
            {
                //ImgCarCrash.Source = new BitmapImage(new Uri("ms-appx:///Assets/img/default.jpg"));
                Debug.WriteLine("in else");
                Debug.WriteLine("URL: " + results.Results[0].SideCrashPicture);

            }



            // string icon = String.Format("", results.Results[0].SideCrashPicture);
        }

    }
}
