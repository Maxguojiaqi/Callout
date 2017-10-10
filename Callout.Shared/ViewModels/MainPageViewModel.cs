using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Callout.ViewModels;
using Esri.ArcGISRuntime.UI.Controls;
// UWP Doesn't support System.Drawing.Color
#if WINDOWS_UWP
using SystemColor = Windows.UI.Colors;
#else
using SystemColor = System.Drawing.Color;
#endif

namespace Callout.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Map _map;
        public Map Map
        {
            get { return _map; }
            private set
            {
                _map = value;
                RaisePropertyChanged();
            }
        }

        private MapView _mymapview;
        public MapView MyMapView
        {
            get { return _mymapview; }
            private set
            {
                _mymapview = value;
                RaisePropertyChanged();
            }
        }

        private GraphicsOverlayCollection _graphicsOverlays = new GraphicsOverlayCollection();
        public GraphicsOverlayCollection GraphicsOverlays
        {
            get { return _graphicsOverlays; }
            set
            {
                _graphicsOverlays = value;
                RaisePropertyChanged();
            }
        }


        public MainPageViewModel()
        {

            MyMapView = new MapView();

            Map = new Map(SpatialReference.Create(102100));

            // Add the tile basemap only after the map has loaded so it doesn't block the map if offline
            Map.Loaded += (sender, e) => { Map.Basemap = Basemap.CreateImagery(); };

            GraphicsOverlay editGraphics = new GraphicsOverlay();
            editGraphics.Id = "MyGraphics";
            GraphicsOverlays.Add(editGraphics);

            // Add some test graphics

            var point = new MapPoint(-3000000, 5000000);
            var pointSymbol = new SimpleMarkerSymbol(SimpleMarkerSymbolStyle.Circle, SystemColor.Red, 25);
            List<KeyValuePair<string, object>> PolyPoint = new List<KeyValuePair<string, object>>();
            PolyPoint.Add(new KeyValuePair<string, object>("Number", 678910));
            PolyPoint.Add(new KeyValuePair<string, object>("Type", "This is Point"));
            Graphic mapPoint = new Graphic(point, PolyPoint, pointSymbol);
            GraphicsOverlays["MyGraphics"].Graphics.Add(mapPoint);

            var travelPolyline = new SimpleLineSymbol(SimpleLineSymbolStyle.Dash, SystemColor.Red, 5);
            var travelPosition = new PolylineBuilder(SpatialReference.Create(102100));
            travelPosition.AddPoint(new MapPoint(0, 0));
            travelPosition.AddPoint(new MapPoint(1000000, 1000000));
            travelPosition.AddPoint(new MapPoint(5000000, 5000000));
            travelPosition.AddPoint(new MapPoint(2000000, 8000000));
            var travelRoute = travelPosition.ToGeometry();
            List<KeyValuePair<string, object>> Polyline = new List<KeyValuePair<string, object>>();
            Polyline.Add(new KeyValuePair<string, object>("Number", 12345));
            Polyline.Add(new KeyValuePair<string, object>("Type", "This is polyline"));
            var travelTrip = new Graphic(travelRoute, Polyline, travelPolyline);
            GraphicsOverlays["MyGraphics"].Graphics.Add(travelTrip);








        }
    }
}
