﻿using System;
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

            MakeRootObject makes = await Makes.GetMakes("1999"); //TODO:change to variable

            for (int i = 0; i <= makes.Results.Count-1; i++)
            {
                MakeList.Add(makes.Results[i].Make);
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
            selected = makeComboBox.SelectedIndex; // get index of year e.g. 2019 = 0
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

            ModelRootObject models = await Models.GetModels("1999", "honda"); // change to y, mk

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