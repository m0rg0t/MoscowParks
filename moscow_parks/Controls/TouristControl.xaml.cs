﻿using moscow_parks.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Шаблон элемента пользовательского элемента управления задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234236

namespace moscow_parks.Controls
{
    public sealed partial class TouristControl : UserControl
    {
        public TouristControl()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemId = ViewModelLocator.MainStatic.CurrentItem.Id;
                ((Frame)Window.Current.Content).Navigate(typeof(ParkDetailPage), itemId.ToString());
            }
            catch { };
        }
    }
}
