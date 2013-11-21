using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MoscowParksWP8.ViewModel;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Input;
using System.Device.Location;
using System.Windows.Shapes;
using System.Windows.Media;
using GART;
using GART.Data;

namespace MoscowParksWP8
{
    public partial class MapPage : PhoneApplicationPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        private void PlaceMap_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DrawMapMarkers();
            }
            catch { };
        }

        private void DrawMapMarkers()
        {
            PlaceMap.Layers.Clear();
            MapLayer mapLayer = new MapLayer();            

            // Draw marker for current position
            if (ViewModelLocator.MainStatic.Items.Count() > 0)
            {
                foreach (var item in ViewModelLocator.MainStatic.Items)
                {
                    DrawMapMarker(item.Position, item, mapLayer);
                };
            }

            PlaceMap.Layers.Add(mapLayer);
            PlaceMap.Center = ViewModelLocator.MainStatic.Items.FirstOrDefault().Position;

            ARDisplay.ARItems.Clear();
            ARDisplay.LocationEnabled = false;
            // Pretend we're here
            ARDisplay.Location = ViewModelLocator.MainStatic.Items.FirstOrDefault().Position;

            foreach (var item in ViewModelLocator.MainStatic.Items)
            {
                ARItem arItem = new ARItem();
                arItem.GeoLocation = item.Position;
                arItem.Content = item.Title.ToString();
                ARDisplay.ARItems.Add(arItem);
            };
        }

        private void DrawMapMarker(GeoCoordinate coordinate, ParkItem place, MapLayer mapLayer)
        {
            // Create a map marker
            //var item = new MapItemControl();

            Polygon polygon = new Polygon();
            polygon.Points.Add(new Point(0, 0));
            polygon.Points.Add(new Point(0, 75));
            polygon.Points.Add(new Point(25, 0));
            polygon.Fill = new SolidColorBrush(Colors.Red);

            // Enable marker to be tapped for location information
            polygon.Tag = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

            //item.Image = place.Image;
            //item.Tag = place.Id; //new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);

            // Enable marker to be tapped for location information            
            //item.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

            // Create a MapOverlay and add marker
            MapOverlay overlay = new MapOverlay();
            overlay.Content = polygon; //polygon;
            overlay.GeoCoordinate = new GeoCoordinate(coordinate.Latitude, coordinate.Longitude);
            overlay.PositionOrigin = new System.Windows.Point(0.5, 1.0);
            mapLayer.Add(overlay);
        }

        private void Marker_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ViewModelLocator.MainStatic.CurrentItem = ViewModelLocator.MainStatic.Items.FirstOrDefault(c => c.Id.ToString() == (sender as Polygon).Tag.ToString());
                this.NavigationService.Navigate(new Uri("/ParkPage.xaml", UriKind.Relative));
            }
            catch { };
        }

        private void ThreeDButton_Click(object sender, EventArgs e)
        {
            try
            {
                UIHelper.ToggleVisibility(this.VideoPreviewItem);
                UIHelper.ToggleVisibility(this.WorldViewItem);
            }
            catch { };
        }

        private void ARDisplay_LocationChanged(object sender, EventArgs e)
        {
            // TODO: For now only search once on startup but later search after the user has traveled some distance
            /*if (lastSearchLocation == null)
            {
                BeginSearch();
            }*/
        }

    }
}