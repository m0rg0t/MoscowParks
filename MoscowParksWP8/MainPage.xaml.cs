using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using MoscowParksWP8.ViewModel;

namespace MoscowParksWP8
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (ViewModelLocator.MainStatic.Items.Count<1)
            {
                ViewModelLocator.MainStatic.LoadData();
            }
        }

        private void RateAppMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ItemsList_ItemTap(object sender, Telerik.Windows.Controls.ListBoxItemTapEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.CurrentItem = (ParkItem)e.Item.Content;
                this.NavigationService.Navigate(new Uri("/ParkPage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void MapTile_Tap(object sender, GestureEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new Uri("/MapPage.xaml", UriKind.Relative));
            }
            catch { };
        }
    }
}