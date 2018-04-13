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
 
        List<int> YearList = new List<int>();
        List<string> MakeList = new List<string>();
        List<string> ModelList = new List<string>();
        private ObservableCollection<VariationResult> VariantList = new ObservableCollection<VariationResult>();
        public int rating = 3;//test

        // vars
        string selectedURL = ""; //TODO: add reset


        public MainPage()
        {
            this.InitializeComponent();
        }

        private async System.Threading.Tasks.Task Page_LoadedAsync(object sender, RoutedEventArgs e)
        {
            YearRootObject myStats = await Years.GetYears();

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            YearRootObject years = await Years.GetYears();

            for (int i = 0; i <= years.Results.Count - 1; i++)
            {
                YearList.Add(years.Results[i].ModelYear);
            }
        }

        private async void Year_Selected(object sender, RoutedEventArgs e)
        {
            string s = "";
            int selectedIndex = 0;
            int selectedValue = 0;

            // reset url
            selectedURL = "";

            // Get the ComboBox instance
            ComboBox yearComboBox = sender as ComboBox;
            selectedIndex = yearComboBox.SelectedIndex; // get index of year e.g. 2019 = 0

            // get value at pos selected
            selectedValue = YearList[selectedIndex];

            s = YearList[selectedIndex].ToString();

            // update selected
            selectedURL = string.Concat(selectedURL, s);

            // change to visible
            lstMake.Visibility = Visibility.Visible;

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

            // reset url
            //selectedURL = "2000"; //TODO: change to a var

            // Get the ComboBox instance
            ComboBox makeComboBox = sender as ComboBox;
            selectedIndex = makeComboBox.SelectedIndex; // get index of year e.g. 2019 = 0

            // get value at pos selected
            selectedValue = MakeList[selectedIndex];

            mk = MakeList[selectedIndex];

            // update selected
            selectedURL = string.Concat(selectedURL, "/make/", mk);

            // change to visible
            lstModel.Visibility = Visibility.Visible;

            ModelRootObject models = await Models.GetModels(selectedURL); // "<year>/make/", <make>

            for (int i = 0; i <= models.Results.Count - 1; i++)
            {
                ModelList.Add(models.Results[i].Model);
            }
        }
        private async void Model_Selected(object sender, RoutedEventArgs e)
        {
            string desc = "";
            int selectedIndex = 0;

            // reset url
            //selectedURL = "2000/make/honda"; //TODO: change to a var

            ComboBox idComboBox = sender as ComboBox;
            ListView lstViewVariation = sender as ListView;
            selectedIndex = idComboBox.SelectedIndex; // get index of year e.g. 2019 = 0
            //selectedIndex = lstViewVariation.SelectedIndex; // get index of year e.g. 2019 = 0
            //Debug.WriteLine("SelectedIndex: " + selectedIndex);

            // get value at pos selected
            //selectedValue = VariantList[0];
            //Debug.WriteLine("SelectedValue: " + selectedValue);

            desc = ModelList[selectedIndex];

            // update selected
            selectedURL = string.Concat(selectedURL, "/model/", desc);
            Debug.WriteLine("SelectedURL: " + selectedURL);

            VariationRootObject variations = await Variation.GetVariations(selectedURL); // "<year>/make/", <make>

            for (int i = 0; i <= variations.Results.Count - 1; i++)
            {
                VariantList.Add(new VariationResult {
                    VehicleDescription = variations.Results[i].VehicleDescription,
                    VehicleId = variations.Results[i].VehicleId
                });

            }
        }

        private void TextBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var vId = ((TextBlock)sender).Tag;

            Frame.Navigate(typeof(VehicleResultPage), vId);
        }
    }
}