using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Device.Location;
using MoscowParksWP8.ViewModel;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using GART;
using GART.Data;
using GART.Controls;
using GART.BaseControls;

namespace MoscowParksWP8
{
    public partial class ParkPage : PhoneApplicationPage
    {
        public ParkPage()
        {
            InitializeComponent();
        }

        private void PlaceMap_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                PlaceMap.Layers.Clear();
                MapLayer mapLayer = new MapLayer();

                // Draw marker for current position
                if (ViewModelLocator.MainStatic.Items.Count() > 0)
                {
                    DrawMapMarker(ViewModelLocator.MainStatic.CurrentItem.Position, ViewModelLocator.MainStatic.CurrentItem, mapLayer);
                }

                PlaceMap.Layers.Add(mapLayer);
                PlaceMap.Center = ViewModelLocator.MainStatic.CurrentItem.Position;
            }
            catch { };
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
            //polygon.MouseLeftButtonUp += new MouseButtonEventHandler(Marker_Click);

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


    }
}