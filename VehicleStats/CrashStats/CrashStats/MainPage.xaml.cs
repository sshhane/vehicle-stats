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
        List<string> MakeList = new List<string>();
        List<string> ModelList = new List<string>();

        // vars
        string selectedURL = ""; //TODO: add reset


        public MainPage()
        {
            this.InitializeComponent();
        }

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
            int selectedIndex = 0;
            int selectedValue = 0;

            // Get the ComboBox instance
            ComboBox yearComboBox = sender as ComboBox;
            selectedIndex = yearComboBox.SelectedIndex; // get index of year e.g. 2019 = 0
            Debug.WriteLine("SelectedIndex: " + selectedIndex);

            // get value at pos selected
            selectedValue = YearList[selectedIndex];
            Debug.WriteLine("SelectedValue: " + selectedValue);

            s = YearList[selectedIndex].ToString();

            // update selected
            selectedURL = string.Concat(selectedURL, s);
            Debug.WriteLine("SelectedURL: " + selectedURL);

            // change to visible
            lstMake.Visibility = Visibility.Visible;
            txtBlockSelectMake.Visibility = Visibility.Visible;

            MakeRootObject makes = await Makes.GetMakes(s); //TODO:change to variable

            for (int i = 0; i <= makes.Results.Count-1; i++)
            {
                MakeList.Add(makes.Results[i].Make);
            }
        }

        private async void Make_Selected(object sender, RoutedEventArgs e)
        {
            string mk = "";
            int selectedIndex = 0;
            string selectedValue = "";

            // Get the ComboBox instance
            ComboBox makeComboBox = sender as ComboBox;
            selectedIndex = makeComboBox.SelectedIndex; // get index of year e.g. 2019 = 0
            Debug.WriteLine("SelectedIndex: " + selectedIndex);

            // get value at pos selected
            selectedValue = MakeList[selectedIndex];
            Debug.WriteLine("SelectedValue: " + selectedValue);

            mk = MakeList[selectedIndex];

            // change to visible
            lstModel.Visibility = Visibility.Visible;
            txtBlockSelectModel.Visibility = Visibility.Visible;

            // Get the ComboBox selected item value and display on TextBlock
            //TextBlock1.Text += "Selected Year : " + yearComboBox.SelectedValue.ToString();
            //YearRootObject years = await Years.GetYears();

            //ResultTextBlock.Text = "Year: " + makes.Results[0].Make;
            for (int i = 0; i <= 29; i++)
            {
            //    MakeList.Add(makes.Results[i].Make);
            }
            //foreach (string mk in MakeList)
            //{
            //    Debug.WriteLine("SelectedURL: " + selectedURL);
            //}
            // Debug.WriteLine("YearList: " + YearList);

            ModelRootObject models = await Models.GetModels(selectedURL, mk); // change to y, mk

            for (int i = 0; i <= models.Results.Count - 1; i++)
            {
                ModelList.Add(models.Results[i].Model);
            }
            //foreach (string mk in MakeList)
            //{
            //    Debug.WriteLine("Make: " + mk);
            //}
        }
        private async void Model_Selected(object sender, RoutedEventArgs e)
        {

        }

    }
}