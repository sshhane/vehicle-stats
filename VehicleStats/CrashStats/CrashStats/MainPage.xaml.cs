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
using System.Collections.ObjectModel;

namespace CrashStats
{

    public sealed partial class MainPage : Page
    {

        List<Students> StuList = new List<Students>();
        List<Years> YearList = new List<Years>();


        public MainPage()
        {

            this.InitializeComponent();

            StuList.Add(new Students()
            {
                ID = 1,
                Name = "Ammar1"
            });

            // GetYears

            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myStats = await OpenStatsProxy.GetStats("honda", "civic", "2000");
            YearRootObject years = await Years.GetYears();

            ResultTextBlock.Text = "Year: " + years.Results[0].ModelYear;
        }

        private ObservableCollection<Result> Results = new ObservableCollection<Result>();

        private async System.Threading.Tasks.Task Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            YearRootObject myStats = await Years.GetYears();

            //foreach (var year in await Years.GetYears("2000")) ;
            //{
            //    Results.Add(year);
            //}
        }
        //private async System.Threading.Tasks.Task MakeLoaded(object sender, RoutedEventArgs e)
        //{
           // MakeRootObject myStats = await Models.GetModels();

            //foreach (var year in await Years.GetYears("2000")) ;
            //{
            //    Results.Add(year);
            //}
        //}
       // private async System.Threading.Tasks.Task ModelLoaded(object sender, RoutedEventArgs e)
        //{
            //ModelRootObject myStats = await Makes.GetMakes();

            //foreach (var year in await Years.GetYears("2000")) ;
            //{
            //    Results.Add(year);
            //}
        //}
    }
}