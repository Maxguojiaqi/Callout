using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Xamarin.Forms;
using Esri.ArcGISRuntime.Symbology;
using System.Collections.Generic;
using Esri.ArcGISRuntime.Data;
using System;
using Callout.ViewModels;

#if WINDOWS_UWP
using Colors = Windows.UI.Colors;
#else
using Colors = System.Drawing.Color;
#endif
namespace Callout
{
	public partial class MapPage : ContentPage
    {
        private MainPageViewModel _viewModel;

        

        public MapPage()
        {
            BindingContext = _viewModel = new MainPageViewModel();

            InitializeComponent();
            MyMapview.GeoViewTapped += OnMapViewTapped;
        }

        //private void Initialize()
        //{
        //    // Hook into tapped event
        //    MyMapview.GeoViewTapped += OnMapViewTapped;
        //}

        public async void OnMapViewTapped(object sender, Esri.ArcGISRuntime.Xamarin.Forms.GeoViewInputEventArgs e)
        {
            var tolerance = 10d; // Use larger tolerance for touch
            var maximumResults = 1; // Only return one graphic  
            var onlyReturnPopups = false; // Don't return only popups
            MapPoint mapLocation = e.Location;
            // Use the following method to identify graphics in a specific graphics overlay
            IdentifyGraphicsOverlayResult identifyResults = await MyMapview.IdentifyGraphicsOverlayAsync(
                 MyMapview.GraphicsOverlays["MyGraphics"],
                 e.Position,
                 tolerance,
                 onlyReturnPopups,
                 maximumResults);

            // Check if we got results
            if (identifyResults.Graphics.Count > 0)
            {
                // initialize the callout, with the title "GeoNote"
                CalloutDefinition myCalloutDefinition = new CalloutDefinition("GeoNote");

                // create a button image, with the buttonclicked action of close the callout
                Uri uri = new Uri("https://www.us.elsevierhealth.com/skin/frontend/enterprise-zurb/themeus/images/close-button.png");
                var image = new RuntimeImage(uri);
                myCalloutDefinition.ButtonImage = image;

                myCalloutDefinition.OnButtonClick = CloseCallout;
                Action<object> ClosePop = CloseCallout;

                void CloseCallout(object i)
                {
                    MyMapview.DismissCallout();
                }

                // Create the Display messge of the callout
                List<object> names = new List<object>();

                string mapLocationDescription = string.Format("this is a piece of information");

                foreach (var g in identifyResults.Graphics)
                {
                    object graphicsName = "Data Type: " + g.Attributes["Type"] + Environment.NewLine;
                    object graphicsNumber = "Number: " + g.Attributes["Number"] + Environment.NewLine;
                    names.Add(graphicsNumber);
                    names.Add(graphicsName);
                }
                string combindedString = string.Join("", names.ToArray());
                myCalloutDefinition.DetailText = "_________________________"+Environment.NewLine + combindedString;

                // Make sure that the UI changes are done in the UI thread
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // Display the callout
                    MyMapview.ShowCalloutAt(mapLocation, myCalloutDefinition);
                });
            }
        }
    }
}
