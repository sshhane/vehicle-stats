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

        //ObservableCollection<int> YearList = new ObservableCollection<int>();

        List<int> YearList = new List<int>();
        List<int> MakeList = new List<int>();
        List<int> ModelList = new List<int>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    RootObject myStats = await OpenStatsProxy.GetStats("honda", "civic", "2000");
        //    YearRootObject years = await Years.GetYears();

        //    ResultTextBlock.Text = "Year: " + years.Results[0].ModelYear;
        //    for (int i=0; i>years.Results.Count(); i++)
        //    {
        //        YearList.Add(years.Results[i].ModelYear);
        //    }
        //}

        //private ObservableCollection<Result> Results = new ObservableCollection<Result>();

        private async System.Threading.Tasks.Task Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            YearRootObject myStats = await Years.GetYears();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            YearRootObject years = await Years.GetYears();

            // ResultTextBlock.Text = "Year: " + years.Results[0].ModelYear;
            for (int i = 0; i <= years.Results.Count - 1; i++)
            {
                YearList.Add(years.Results[i].ModelYear);
            }
            foreach (int y in YearList)
            {
                Debug.WriteLine("Year: " + y);
            }
        }

        private async void Year_Selected(object sender, RoutedEventArgs e)
        {
            string s = "";
            int selected = 0;

            // Get the ComboBox instance
            ComboBox yearComboBox = sender as ComboBox;
            selected = yearComboBox.SelectedIndex; // get index of year e.g. 2019 = 0
            Debug.WriteLine("Selected: " + selected);

            s = YearList[selected].ToString();
           // MakeRootObject makes = await Makes.GetMakes(s);
            //Makes.GetMakes(s);

            // change to visible
            lstMake.Visibility = Visibility.Visible;
            txtBlockSelectMake.Visibility = Visibility.Visible;

            // Get the ComboBox selected item value and display on TextBlock
            //TextBlock1.Text += "Selected Year : " + yearComboBox.SelectedValue.ToString();
            //YearRootObject years = await Years.GetYears();

            //ResultTextBlock.Text = "Year: " + makes.Results[0].Make;
            //for (int i = 0; i <= 29; i++)
            //{
            //    MakeList.Add(makes.Results[i].Make);
            //}
            //foreach (string mk in MakeList)
            //{
            //    Debug.WriteLine("Make: " + mk);
            //}
            // Debug.WriteLine("YearList: " + YearList);

            MakeRootObject makes = await Makes.GetMakes("honda");

            for (int i = 0; i <= makes.Results.Count-1; i++)
            {
            //    MakeList.Add(makes.Results[i].Make);
            }
            //foreach (string mk in MakeList)
            //{
            //    Debug.WriteLine("Make: " + mk);
            //}
        }

        private async void Make_Selected(object sender, RoutedEventArgs e)
        {
            string s = "";
            int selected = 0;

            // Get the ComboBox instance
            ComboBox makeComboBox = sender as ComboBox;
            selected = makeComboBox.SelectedIndex; // get index of make e.g. acura = 0
            Debug.WriteLine("Selected: " + selected);

            s = MakeList[selected].ToString();
            // MakeRootObject makes = await Makes.GetMakes(s);
            //Makes.GetMakes(s);

            // change to visible
            lstModel.Visibility = Visibility.Visible;
            txtBlockSelectModel.Visibility = Visibility.Visible;

            // Get the ComboBox selected item value and display on TextBlock
            //TextBlock1.Text += "Selected Year : " + yearComboBox.SelectedValue.ToString();
            //YearRootObject years = await Years.GetYears();

            //ResultTextBlock.Text = "Year: " + makes.Results[0].Make;
            //for (int i = 0; i <= 29; i++)
            //{
            //    MakeList.Add(makes.Results[i].Make);
            //}
            //foreach (string mk in MakeList)
            //{
            //    Debug.WriteLine("Make: " + mk);
            //}
            // Debug.WriteLine("YearList: " + YearList);
        }
        private async void Model_Selected(object sender, RoutedEventArgs e)
        {

        }

    }
}