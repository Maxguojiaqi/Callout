using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.UI;
using Xamarin.Forms;
using Esri.ArcGISRuntime.Symbology;
using System.Collections.Generic;
using Esri.ArcGISRuntime.Data;
using System;


#if WINDOWS_UWP
using Colors = Windows.UI.Colors;
#else
using Colors = System.Drawing.Color;
#endif
namespace Callout
{
	public partial class MapPage : ContentPage
    {
        private GraphicsOverlay _polygonOverlay;
        public MapPage()
        {
            InitializeComponent();

            Title = "Identify graphics";

            // Create the UI, setup the control references and execute initialization 
            Initialize();
        }

        private void Initialize()
        {
            // Create a map with 'Imagery with Labels' basemap and an initial location
            Map myMap = new Map(Basemap.CreateTopographic());



            // Create graphics overlay with graphics
            CreateOverlay();

            // Hook into tapped event
            MyMapView.GeoViewTapped += OnMapViewTapped;

            // Assign the map to the MapView
            MyMapView.Map = myMap;
        }
        #region add overlay
        private void CreateOverlay()
        {
            // Create polygon builder and add polygon corners into it
            PolygonBuilder builder = new PolygonBuilder(SpatialReferences.WebMercator);
            builder.AddPoint(new MapPoint(-20e5, 20e5));
            builder.AddPoint(new MapPoint(20e5, 20e5));
            builder.AddPoint(new MapPoint(20e5, -20e5));
            builder.AddPoint(new MapPoint(-20e5, -20e5));

            // Get geometry from the builder
            Polygon polygonGeometry = builder.ToGeometry();

            // Create symbol for the polygon
            SimpleFillSymbol polygonSymbol = new SimpleFillSymbol(
                SimpleFillSymbolStyle.Solid,
               Colors.Yellow,
                null);

            List<KeyValuePair<string, object>> Polygon = new List<KeyValuePair<string, object>>();
            Polygon.Add(new KeyValuePair<string, object>("IntNotEnumerable", 678910));
            Polygon.Add(new KeyValuePair<string, object>("name", "This is polygon"));

            // Create new graphic
            Graphic polygonGraphic = new Graphic(polygonGeometry, Polygon, polygonSymbol);

            // Create overlay to where graphics are shown
            _polygonOverlay = new GraphicsOverlay();
            _polygonOverlay.Graphics.Add(polygonGraphic);

            var travelPolyline = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, Colors.Red, 5);
            var travelPosition = new PolylineBuilder(SpatialReference.Create(102100));
            travelPosition.AddPoint(new MapPoint(0, 0));
            travelPosition.AddPoint(new MapPoint(1000000, 1000000));
            travelPosition.AddPoint(new MapPoint(5000000, 5000000));
            travelPosition.AddPoint(new MapPoint(2000000, 8000000));
            var travelRoute = travelPosition.ToGeometry();
            List<KeyValuePair<string, object>> Polyline = new List<KeyValuePair<string, object>>();
            Polyline.Add(new KeyValuePair<string, object>("IntNotEnumerable", 12345));
            Polyline.Add(new KeyValuePair<string, object>("name", "This is polyline"));


            var travelTrip = new Graphic(travelRoute, Polyline, travelPolyline);
            _polygonOverlay.Graphics.Add(travelTrip);

            // Add created overlay to the MapView
            MyMapView.GraphicsOverlays.Add(_polygonOverlay);
        }
        #endregion

        private async void OnMapViewTapped(object sender, Esri.ArcGISRuntime.Xamarin.Forms.GeoViewInputEventArgs e)
        {
            var tolerance = 10d; // Use larger tolerance for touch
            var maximumResults = 1; // Only return one graphic  
            var onlyReturnPopups = false; // Don't return only popups
            MapPoint mapLocation = e.Location;
            // Use the following method to identify graphics in a specific graphics overlay
            IdentifyGraphicsOverlayResult identifyResults = await MyMapView.IdentifyGraphicsOverlayAsync(
                 _polygonOverlay,
                 e.Position,
                 tolerance,
                 onlyReturnPopups,
                 maximumResults);

            // Check if we got results
            if (identifyResults.Graphics.Count > 0)
            {
                List<object> names = new List<object>();

                string mapLocationDescription = string.Format("this is a piece of information");

                foreach (var g in identifyResults.Graphics)
                {
                    object graphicsName = g.Attributes["IntNotEnumerable"];
                    names.Add(graphicsName); 
                }
                string combindedString = string.Join(",", names.ToArray());
                // Create a new callout definition using the formatted string
                CalloutDefinition myCalloutDefinition = new CalloutDefinition("GeoNote");
                //CalloutStyle callout = new CalloutStyle();
                //callout.BackgroundColor = Colors.Red;
                myCalloutDefinition.DetailText = "Name " + combindedString;
                Uri uri = new Uri("https://www.edenprairienissan.com/wp-content/themes/DealerInspireDealerTheme/images/close-button.png");
                var image = new RuntimeImage(uri);
                myCalloutDefinition.ButtonImage = image;

                myCalloutDefinition.OnButtonClick = CloseCallout;
                Action<object> ClosePop = CloseCallout;

                void CloseCallout(object i)
                {
                    MyMapView.DismissCallout();
                }

                //// Display the callout
                //MyMapView.ShowCalloutAt(mapLocation, myCalloutDefinition);

                // Make sure that the UI changes are done in the UI thread
                Device.BeginInvokeOnMainThread(async () =>
                {
                    // Display the callout
                    MyMapView.ShowCalloutAt(mapLocation, myCalloutDefinition);
                });
            }
        }
    }
}
