using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using C1.Silverlight.Maps;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using System.Diagnostics;
using iDeal.silverlight.classes;

namespace iDeal.silverlight.controls
{
   
    public partial class CMapControl : UserControl
    {

        public static string FormatCoordinates(Point p, ECoordinatesView view)
        {
            string yonX = "E";
            if (p.X < 0) { yonX = "W"; p.X *= -1; }

            string yonY = "N";
            if (p.Y < 0) { yonY = "S"; p.Y *= -1; }

            switch (view)
            {
                case ECoordinatesView.DegMinSec:
                     int dereceX1 = (int)p.X;
                    double dakikaX1 = ((p.X - dereceX1) * 60);

                    int dereceY1 = (int)p.Y;
                    double dakikaY1 = ((p.Y - dereceY1) * 60);

                    int saniyeX1=(int)((dakikaX1 - (int)dakikaX1) * 60);
                    int saniyeY1=(int)((dakikaY1 - (int)dakikaY1) * 60); 

                    return
                      dereceY1.ToString("00° ") + ((int)dakikaY1).ToString("00") +"' " + saniyeY1.ToString("00") + "'' "+ yonY + "  " +
                      dereceX1.ToString("00° ") + ((int)dakikaX1).ToString("00") + "' " + saniyeX1.ToString("00") + "'' " + yonX;
                case ECoordinatesView.DegMin:
                    int dereceX = (int)p.X;
                    double dakikaX = ((p.X - dereceX) * 60);

                    int dereceY = (int)p.Y;
                    double dakikaY = ((p.Y - dereceY) * 60);

                    return
                        dereceY.ToString("00° ") + ((int)dakikaY).ToString("00") + "'" + (dakikaY - (int)dakikaY).ToString(".###0 ") + yonY + "  " +
                        dereceX.ToString("00° ") + ((int)dakikaX).ToString("00") + "'" + (dakikaX - (int)dakikaX).ToString(".###0 ") + yonX;

                case ECoordinatesView.Deg:
                default:
                    return
                       p.Y.ToString("00°.######0 " + yonY + "  ") +
                       p.X.ToString("00°.######0 " + yonX );
            }
        }

        #region EVENTS

        public event PolygonCreated OnPolygonCreated;

        public event RulerValueChanged OnRulerValueChanged;

        public event ZoomControl OnZoomChanged;

        public event MouseButtonEventHandler OnClicked;

        #endregion

        #region PROPERTIES

        public C1MapItemsLayer ItemLayer { get { return mapItemsLayer; } }

        public C1VectorLayer VectorLayer { get { return vectorLayer; } }

        public C1MapVirtualLayer VirtualLayer { get { return virtualLayer; } }

        public Dictionary<string, C1MapItemsLayer> ItemLayersDict { get { return itemLayersDict; } }

        public Dictionary<string, C1VectorLayer> VectorLayersDict { get { return vectorLayersDict; } }

        public Point Center { get { return map.Center; } set { map.Center = value; } }

        public double Zoom { get { return map.Zoom; } set { map.Zoom = value; } }

        public Collection<IMapLayer> Layers { get { return map.Layers; } }

        public Point InitialCenter { get { return initialCenter0; } }
        public Point TaggedCenter0 { get { return initialCenter0; } }
        public Point TaggedCenter1 { get { return initialCenter1; } }
        public Point TaggedCenter2 { get { return initialCenter2; } }
        

        public bool ShowMapSource
        {
            get { return btnMapSource.Visibility == Visibility.Visible; }
            set { btnMapSource.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowRuler
        {
            get { return btnRuler .Visibility == Visibility.Visible; }
            set { btnRuler.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowRegion
        {
            get { return btnPolygon .Visibility == Visibility.Visible; }
            set { btnPolygon.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowPositionSet
        {
            get { return btngrTag .Visibility == Visibility.Visible; }
            set { btngrTag.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowZoomButton
        {
            get { return btngrZoom  .Visibility == Visibility.Visible; }
            set { btngrZoom.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

     

        public bool ShowFullScreen
        {
            get { return btnFullScreen .Visibility == Visibility.Visible; }
            set { btnFullScreen.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowHelp
        {
            get { return btnHelp .Visibility == Visibility.Visible; }
            set { btnHelp.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public bool ShowiDealTeknoloji
        {
            get { return textBlock1.Visibility == Visibility.Visible; }
            set { textBlock1.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public UIElementCollection Children { get { return LayoutRoot.Children; } }

        public EMapSource MapSource
        {
            get
            {
                if (map.Source is iDealRTSMapSource) return EMapSource.RTS;
                if (map.Source is iDealMapSource) return EMapSource.iDeal;
                if (map.Source is GoogleSatSource) return EMapSource.GoogleSat;
                if (map.Source is GoogleMapSource) return EMapSource.GoogleMap;
                if (map.Source is VirtualEarthMapSource ) return EMapSource.VirtualEarth;
                if (map.Source is OpenStreetMapSource) return EMapSource.VirtualEarth;
                return EMapSource.None;
            }
            set
            {
                switch (value)
                {
                    case EMapSource.RTS:
                        map.Source = new iDealRTSMapSource();
                        break;
                    case EMapSource.iDeal:
                        map.Source = new iDealMapSource();
                        break;
                    case EMapSource.GoogleSat:
                        map.Source = new GoogleSatSource();
                        break;
                    case EMapSource.GoogleMap:
                        map.Source = new GoogleMapSource();
                        break;
                    case EMapSource.VirtualEarth:
                        map.Source = new VirtualEarthMapSource();
                        break;
                    case EMapSource.OpenStreetMap:
                        map.Source = new OpenStreetMapSource();
                        break;
                }
            }

        }

        public double MaxZoom
        {
            get { return maxZoom; }
            set { maxZoom = value; }
        }

        public double MinZoom
        {
            get { return minZoom; }
            set { minZoom = value; }
        }

        public ECoordinatesView CoordinatesView
        {
            get { return coordinatesView; }
            set { coordinatesView = value; }
        }

        public Brush Stroke { get { return rectangle.Stroke; } set { rectangle.Stroke = value; } }

        public Key PressedKey { get { return pressedKey; } }
        #endregion

        #region CTORs

        public CMapControl()
        {
            InitializeComponent();
            Loaded += (o, e) =>
                {
                    //messageLabel.Text = coordinatesLabel.Text = "";
gridMessage.Visibility =Visibility.Collapsed;
                };
          
            btngrTag .Clicked +=new CGroupButtonsClickEventHandler(btngrTag_Clicked);
            btngrZoom .Clicked+=new CGroupButtonsClickEventHandler(btngrZoom_Clicked);
            Application.Current.Host.Content.FullScreenChanged += new EventHandler(Content_FullScreenChanged);

            messageTimer.Interval = TimeSpan.FromSeconds(3);
            messageTimer.Tick += (o, ea) =>
            {
                //messageLabel.Text = "";
                gridMessage.Visibility = Visibility.Collapsed;
				messageTimer.Stop();
            };



            string x = CService.LoadData("MapCenterX");
            string y = CService.LoadData("MapCenterY");
            string zoom = CService.LoadData("Zoom");

            double X = 27, Y = 38.5;

            if (!string.IsNullOrEmpty(x) && !string.IsNullOrEmpty(y))
            {

                double.TryParse(x, out X);
                double.TryParse(y, out Y);
                double.TryParse(zoom, out initialZoom0);
            }
            initialCenter0.X = X;
            initialCenter0.Y = Y;
            map.Center = initialCenter0;
            map.Zoom = initialZoom0;

            map.MouseLeftButtonDown += new MouseButtonEventHandler(map_MouseLeftButtonDown);
            map.MouseLeftButtonUp += new MouseButtonEventHandler(map_MouseLeftButtonUp);
            map.MouseMove += new MouseEventHandler(map_MouseMove);
            map.MouseMove += new MouseEventHandler(map_MouseMove_ZoomRectangle);
            map.MouseRightButtonDown += new MouseButtonEventHandler(map_MouseRightButtonDown_RulerAndRegion);
            map.MouseRightButtonDown += new MouseButtonEventHandler(map_MouseRightButtonDown_ZoomRectangle);
            map.MouseRightButtonUp += new MouseButtonEventHandler(map_MouseRightButtonUp_ZoomRectangle);
            map.ZoomChanged += new EventHandler<C1.Silverlight.PropertyChangedEventArgs<double>>(map_ZoomChanged);
            map.MouseWheel += new MouseWheelEventHandler(map_MouseWheel);
            map.CenterChanged += new EventHandler<C1.Silverlight.PropertyChangedEventArgs<Point>>(map_CenterChanged);
            map.TargetZoomChanged += new EventHandler<C1.Silverlight.PropertyChangedEventArgs<double>>(map_TargetZoomChanged);
            MapSource = EMapSource.GoogleSat;

            map1.Source = new VirtualEarthHybridSource();

            AddVectorLayer("VectorLayer", vectorLayer);
            AddMapItemsLayer("ItemLayer", mapItemsLayer);

            coordinatesLabel.MouseLeftButtonUp += new MouseButtonEventHandler(coordinatesLabel_MouseLeftButtonUp);

        }

       

      

     

        #endregion

        #region METHODs

        public void Go(Point targetCenter, double targetZoom)
        {

            var sbChangeCenter = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(1)
            };
            var centerAnimation = new PointAnimation { From = map.Center, To = targetCenter };

            Storyboard.SetTargetProperty(centerAnimation, new PropertyPath(C1Maps.CenterProperty));
            sbChangeCenter.Children.Add(centerAnimation);

            Storyboard.SetTarget(sbChangeCenter, map);

            sbChangeCenter.Begin();
            sbChangeCenter.Completed += (s2, e2) =>
            {
                map.Center = targetCenter;

            };
            var sbChangeZoom = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(1)
            };

            sbChangeZoom.Completed += (s, e) =>
            {

                map.Zoom = targetZoom;
            };

            var zoomOutAnimation = new DoubleAnimation { To = targetZoom };
            Storyboard.SetTargetProperty(zoomOutAnimation, new PropertyPath(C1Maps.ZoomProperty));
            sbChangeZoom.Children.Add(zoomOutAnimation);
            Storyboard.SetTarget(sbChangeZoom, map);
            sbChangeZoom.Begin();
        }

        public void Go(Point targetCenter)
        {

            var sbChangeCenter = new Storyboard
            {
                Duration = TimeSpan.FromSeconds(1)
            };


            var centerAnimation = new PointAnimation { To = targetCenter };
            Storyboard.SetTargetProperty(centerAnimation, new PropertyPath(C1Maps.CenterProperty));
            sbChangeCenter.Children.Add(centerAnimation);

            Storyboard.SetTarget(sbChangeCenter, map);

            sbChangeCenter.Begin();
            sbChangeCenter.Completed += (s2, e2) =>
            {
                map.Center = targetCenter;

            };
        }

        public void AddVectorLayer(string VectorLayerName, C1VectorLayer vectorLayer)
        {
            VectorLayersDict.Add(VectorLayerName, vectorLayer);
            map.Layers.Add(vectorLayer);
        }

        public void AddMapItemsLayer(string MapItemsLayerName, C1MapItemsLayer itemLayer)
        {
            ItemLayersDict.Add(MapItemsLayerName, itemLayer);
            map.Layers.Add(itemLayer);

        }
       
        public void AddToItemsLayer(object item)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ItemLayer.Items.Add(item);
            });
        }

        public void RemoveFromItemsLayer(object item)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ItemLayer.Items.Remove(item);
            });
        }

        public Point SCreenToGeopraphic(object sender, MouseButtonEventArgs e)
        {
            return map.ScreenToGeographic(e.GetPosition(map));
        }

        public Point GeographicToScreen(Point geoPoint)
        {
            return map.GeographicToScreen(geoPoint);
        }
        
        public Point ScreenToGeographic(Point screenPoint)
        {
            return map.ScreenToGeographic(screenPoint);
        }

        public double GetScreenLength(Point refPoint,double geoLength)
        {
            CMercator m=new CMercator();
            double y= m.lat (m.y(refPoint.Y) + geoLength);
            Point y1=map.GeographicToScreen(refPoint);
            Point y2=map.GeographicToScreen(new Point(refPoint.X,y));
            return Math.Abs (y1.Y-y2.Y);
        }

        public void ZoomIn()
        {
            Zoom++;
        }

        public void ZoomOut()
        {
            Zoom--;
        }

        #endregion

        /***********************************************************************************************************/

        #region FIELDs

        Point mouseDownPoint = new Point(0, 0);
        Point mouseUpPoint = new Point(0, 0);
        Point mousePoint = new Point(0, 0);
        PointCollection points = new PointCollection();
        Point initialCenter0 = new Point(27, 38.5);
        Point initialCenter1 = new Point(27, 38.5);
        Point initialCenter2 = new Point(27, 38.5);


        Rectangle boundary=new Rectangle();

        C1MapVirtualLayer virtualLayer = new C1MapVirtualLayer();
        C1MapItemsLayer mapItemsLayer = new C1MapItemsLayer();
        C1VectorLayer vectorLayer = new C1VectorLayer();

        Dictionary<string, C1MapItemsLayer> itemLayersDict = new Dictionary<string, C1MapItemsLayer>();
        Dictionary<string, C1VectorLayer> vectorLayersDict = new Dictionary<string, C1VectorLayer>();
        C1VectorPolyline lines         = null;
        C1VectorPolygon poly           = null;
        Key pressedKey                 = Key.None;
        DispatcherTimer messageTimer   = new DispatcherTimer();
        C1VectorPlacemark startingPoint = new C1VectorPlacemark();
        SolidColorBrush zoomRectStrokeBrush_Blue=new SolidColorBrush(Colors.Blue);
        SolidColorBrush zoomRectStrokeBrush_Red=new SolidColorBrush(Colors.Red);
        SolidColorBrush zoomRectFillBrush_Blue=new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));
        SolidColorBrush zoomRectFillBrush_Red=new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));


        bool rulerOn                   = false;
        bool regionOn                  = false;
        int mapCounter                 = 2;
        double initialZoom0             = 10;
        double initialZoom1             = 10;
        double initialZoom2             = 10;
        bool rightMouseButtonDown=false;
        double minZoom=2;
        double maxZoom=19;
        ECoordinatesView coordinatesView=ECoordinatesView.DegMin;
        #endregion

        #region MAP CONTROL EVENT METHODs

        void map_MouseRightButtonDown_ZoomRectangle(object sender, MouseButtonEventArgs e)
        {
            mouseDownPoint = map.ScreenToGeographic(e.GetPosition(map));
            if (!(rulerOn || regionOn))
            {
                rightMouseButtonDown = true;
            }
            e.Handled = true;
        }

        void map_MouseRightButtonUp_ZoomRectangle(object sender, MouseButtonEventArgs e)
        {
            mouseUpPoint = map.ScreenToGeographic(e.GetPosition(map));
            if (!(rulerOn || regionOn))
            {
                rightMouseButtonDown = false;
                vectorLayer.Children.Remove(poly);
                if (mouseDownPoint.X > mouseUpPoint.X) Go(MidPoint(mouseDownPoint, mouseUpPoint), map.Zoom - 1);
                else Go(MidPoint(mouseDownPoint, mouseUpPoint), map.Zoom + 1);
            }

        }

        void map_TargetZoomChanged(object sender, C1.Silverlight.PropertyChangedEventArgs<double> e)
        {
            //Debug.WriteLine(e.NewValue);
            if (e.NewValue < minZoom || e.NewValue >maxZoom ) map.TargetZoomSpeed = 0;
            else map.TargetZoomSpeed = .5;
         
        }

        void map_ZoomChanged(object sender, C1.Silverlight.PropertyChangedEventArgs<double> e)
        {
            
            //if (map.Zoom <= minZoom || map.Zoom >= maxZoom) return;
            //Debug.WriteLine(map.Zoom);
             map.Zoom = Math.Max(minZoom, Math.Min(maxZoom, map.Zoom));
            if (map.Zoom > 10)
            {
                map1.Zoom = map.Zoom - 10;
            }
            if (OnZoomChanged != null)
                OnZoomChanged();

        }

        void map_CenterChanged(object sender, C1.Silverlight.PropertyChangedEventArgs<Point> e)
        {
            map1.Center = map.Center;
        }

        void map_MouseRightButtonDown_RulerAndRegion(object sender, MouseButtonEventArgs e)
        {
            if ((rulerOn || regionOn) && points.Count > 0)
            {
                points.RemoveAt(points.Count - 1);

                if (points.Count == 0)
                {
                    if (vectorLayer.Children.Contains(startingPoint)) vectorLayer.Children.Remove(startingPoint);
                }
                //if (points.Count > 0) points[points.Count - 1] = map.ScreenToGeographic(e.GetPosition(map));
                if (rulerOn)
                {
                    DrawLine();
                    double distance = 0;
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        distance += C1Maps.Distance(points[i], points[i + 1]);
                    }
                    if (OnRulerValueChanged != null) OnRulerValueChanged(this, distance);
                    messageLabel.Text = distance > 1000 ? (distance / 1000).ToString("#,0.0 km") : distance.ToString("#,0.0 m");
                }
                else if (regionOn) DrawPolygon();
            }

        }

        void map_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mouseDownPoint = e.GetPosition(map);
            if ((rulerOn || regionOn) && points.Count == 0)
            {
                if (vectorLayer.Children.Contains(startingPoint)) vectorLayer.Children.Remove(startingPoint);

                vectorLayer.Children.Add(startingPoint);
                startingPoint.Label = "x";
                startingPoint.GeoPoint = map.ScreenToGeographic(mouseDownPoint);
                startingPoint.FontSize = 14;
                startingPoint.Foreground = new SolidColorBrush(Colors.Red);
                startingPoint.LabelPosition = LabelPosition.Center;




            }
        }

        void map_MouseMove(object sender, MouseEventArgs e)
        {
            mousePoint = map.ScreenToGeographic(e.GetPosition(map));
            DrawCoordinates();
            if (points.Count > 0)
            {

                if (rulerOn)
                {
                    if (points.Count > 1)
                        points[points.Count - 1] = map.ScreenToGeographic(e.GetPosition(map));
                    DrawLine();
                    double distance = 0;
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        distance += C1Maps.Distance(points[i], points[i + 1]);
                    }
                    messageLabel.Text = distance > 1000 ? (distance / 1000).ToString("#,0.0 km") : distance.ToString("#,0.0 m");
                }
            }

        }
       
        void map_MouseMove_ZoomRectangle(object sender, MouseEventArgs e)
        {

            if (rightMouseButtonDown && !(rulerOn || regionOn))
            {
                DrawZoomRectangle(mouseDownPoint, mousePoint);
            }


        }

        void map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (OnClicked != null) OnClicked(this, e);
            if (mouseDownPoint == e.GetPosition(map))
            {
                points.Add(map.ScreenToGeographic(e.GetPosition(map)));
                if (rulerOn) DrawLine();
                else if (regionOn) DrawPolygon();

            }
        }

        void map_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            e.Handled = true;
        }


        #endregion

        #region METHODs

        void coordinatesLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (coordinatesView == ECoordinatesView.DegMin)
            {
                coordinatesView = ECoordinatesView.Deg;
            }
            else
            {
                coordinatesView = ECoordinatesView.DegMin;
            }
            DrawCoordinates();
        }

        void Content_FullScreenChanged(object sender, EventArgs e)
        {
            btnFullScreen .IsChecked = Application.Current.Host.Content.IsFullScreen;
        }

        void poly_MouseLeave(object sender, MouseEventArgs e)
        {
            C1VectorPolygon vp = sender as C1VectorPolygon;
            SolidColorBrush br = vp.Fill as SolidColorBrush;
            br.Color = Color.FromArgb(70, br.Color.R, br.Color.G, br.Color.B);
        }

        void poly_MouseEnter(object sender, MouseEventArgs e)
        {
            C1VectorPolygon vp = sender as C1VectorPolygon;
            SolidColorBrush br = vp.Fill as SolidColorBrush;
            br.Color = Color.FromArgb(220, br.Color.R, br.Color.G, br.Color.B);
        }

        void poly_MouseMove(object sender, MouseEventArgs e)
        {


        }

    
        void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKey |= e.Key;
        }

        void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey ^= e.Key;
        }

    
        //void ZoomIn()
        //{
        //    if (map.Zoom < maxZoom)
        //    {
        //        map.TargetZoom = map.Zoom;
        //        var storyboard1 = new Storyboard
        //        {
        //            Duration = TimeSpan.FromSeconds(1)
        //        };
        //        var zoomOutAnimation = new DoubleAnimation { To = map.TargetZoom + 1 };
        //        Storyboard.SetTargetProperty(zoomOutAnimation, new PropertyPath(C1Maps.ZoomProperty));
        //        storyboard1.Children.Add(zoomOutAnimation);
        //        Storyboard.SetTarget(storyboard1, map);
        //        storyboard1.Begin();
        //    }
        //}

        //void ZoomOut()
        //{
        //    if (map.Zoom > minZoom)
        //    {
        //        map.TargetZoom = map.Zoom;
        //        var storyboard1 = new Storyboard
        //        {
        //            Duration = TimeSpan.FromSeconds(1)
        //        };
        //        var zoomOutAnimation = new DoubleAnimation { To = map.TargetZoom - 1 };
        //        Storyboard.SetTargetProperty(zoomOutAnimation, new PropertyPath(C1Maps.ZoomProperty));
        //        storyboard1.Children.Add(zoomOutAnimation);
        //        Storyboard.SetTarget(storyboard1, map);
        //        storyboard1.Begin();
        //    }
        //}

        Point MidPoint(Point p1, Point p2)
        {
            return new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
        }

        void DrawLine()
        {
            if (lines != null) vectorLayer.Children.Remove(lines);
            lines = new C1VectorPolyline();
            lines.Stroke = new SolidColorBrush(Colors.Yellow);
            lines.StrokeThickness = 2;
            lines.StrokeLineJoin = PenLineJoin.Round;
            lines.StrokeDashCap = PenLineCap.Round;
            lines.StrokeEndLineCap = PenLineCap.Round;

            lines.Points = points;


            vectorLayer.Children.Add(lines);

        }

        void DrawPolygon()
        {
            if (poly != null) vectorLayer.Children.Remove(poly);
            poly = new C1VectorPolygon();
            poly.Stroke = new SolidColorBrush(Colors.Yellow);
            poly.StrokeThickness = 2;
            poly.StrokeLineJoin = PenLineJoin.Round;
            poly.StrokeDashCap = PenLineCap.Round;
            poly.StrokeEndLineCap = PenLineCap.Round;
            poly.Fill = new SolidColorBrush(Color.FromArgb(100, 255, 255, 255));
            poly.Points = points;


            vectorLayer.Children.Add(poly);

        }

        void DrawZoomRectangle(Point p1, Point p2)
        {

            if (poly != null) vectorLayer.Children.Remove(poly);
            poly = new C1VectorPolygon();
            poly.Stroke = p1.X > p2.X ? zoomRectStrokeBrush_Red : zoomRectStrokeBrush_Blue;
            poly.StrokeThickness = 2;
            poly.StrokeLineJoin = PenLineJoin.Round;
            poly.StrokeDashCap = PenLineCap.Round;
            poly.StrokeEndLineCap = PenLineCap.Round;
            poly.Fill = p1.X > p2.X ? zoomRectFillBrush_Red : zoomRectFillBrush_Blue;
            poly.Points = new PointCollection() {   new Point(p1.X,p1.Y),
                                                    new Point(p1.X,p2.Y),
                                                    new Point(p2.X,p2.Y),
                                                    new Point(p2.X,p1.Y)};


            vectorLayer.Children.Add(poly);
        }

        void DrawCoordinates()
        {

            coordinatesLabel.Text = FormatCoordinates(mousePoint, coordinatesView);

        }

        void Message(string msg)
        {
            messageLabel.Text = msg;
            gridMessage.Visibility = Visibility.Visible; 
            messageTimer.Start();
        }

        #endregion

        private void btnMapSource_Clicked(object sender, EventArgs e)
        {
            MapSource = (EMapSource)(++mapCounter % 6);
        }

        private void btnRuler_Clicked(object sender, EventArgs e)
        {
           
                points.Clear();
                if (lines != null) vectorLayer.Children.Remove(lines);
                rulerOn = btnRuler.IsChecked;
                if (!rulerOn)
                {
                    messageLabel.Text = "";
                    gridMessage.Visibility = Visibility.Collapsed;
                    if (vectorLayer.Children.Contains(startingPoint)) vectorLayer.Children.Remove(startingPoint);
                }
                else btnPolygon.IsChecked = false;
           
        }
        public void BeginRulerMode()
        {
            rulerOn = true;
            messageLabel.Text = "";
            gridMessage.Visibility = Visibility.Visible;
            if (vectorLayer.Children.Contains(startingPoint)) vectorLayer.Children.Remove(startingPoint);
        }
        public void EndRulerMode()
        {
            points.Clear();
            if (lines != null) vectorLayer.Children.Remove(lines);
            gridMessage.Visibility = Visibility.Collapsed;
            rulerOn = false;
        }
        private void btnPolygon_Clicked(object sender, EventArgs e)
        {
           
                if (poly != null) vectorLayer.Children.Remove(poly);
                regionOn = btnPolygon.IsChecked;
                if (!regionOn)
                {
                    gridMessage.Visibility = Visibility.Collapsed;
                    messageLabel.Text = "";
                    if (OnPolygonCreated != null)  OnPolygonCreated(this, points);
                    if (vectorLayer.Children.Contains(startingPoint)) vectorLayer.Children.Remove(startingPoint);

                }
                else btnRuler.IsChecked = false;
                points.Clear();
            
        }

      
        private void btngrZoom_Clicked(CButton sender)
        {
            switch (sender.Index)
            {
                case 1:
                    ZoomIn();
                    break;
                case 0:
                    ZoomOut();
                    break;
            }
        }

        private void btngrTag_Clicked(CButton sender)
        {
            switch (sender.Index)
            {
                case 0:
                    if (pressedKey == Key.Ctrl || pressedKey == Key.Shift)
                    {
                        CService.SaveData(map.Center.X.ToString(), "MapCenterX");
                        CService.SaveData(map.Center.Y.ToString(), "MapCenterY");
                        CService.SaveData(map.Zoom.ToString(), "Zoom");
                        Message("Başlangıç pozisyonu kaydedildi.");
                        initialCenter0 = map.Center;
                        initialZoom0 = map.Zoom;
                    }
                    else
                    {
                        Go(initialCenter0, initialZoom0);
                    }
                    break;
                case 1:
                    if (pressedKey == Key.Ctrl || pressedKey == Key.Shift)
                    {
                        CService.SaveData(map.Center.X.ToString(), "MapCenterX");
                        CService.SaveData(map.Center.Y.ToString(), "MapCenterY");
                        CService.SaveData(map.Zoom.ToString(), "Zoom");
                        Message("Başlangıç pozisyonu kaydedildi.");
                        initialCenter1 = map.Center;
                        initialZoom1 = map.Zoom;
                    }
                    else
                    {
                        Go(initialCenter1, initialZoom1);
                    }
                    break;
                case 2:
                    if (pressedKey == Key.Ctrl || pressedKey == Key.Shift)
                    {
                        CService.SaveData(map.Center.X.ToString(), "MapCenterX");
                        CService.SaveData(map.Center.Y.ToString(), "MapCenterY");
                        CService.SaveData(map.Zoom.ToString(), "Zoom");
                        Message("Başlangıç pozisyonu kaydedildi.");
                        initialCenter2 = map.Center;
                        initialZoom2 = map.Zoom;
                    }
                    else
                    {
                        Go(initialCenter2, initialZoom2);
                    }
                    break;
                default:
                    break;
            }
        }

     

        private void btnFullScreen_Clicked(object sender, EventArgs e)
        {
            Application.Current.Host.Content.IsFullScreen = btnFullScreen .IsChecked ;
        }

        private void btnHelp_Clicked(object sender, EventArgs e)
        {
            AboutWindow w = new AboutWindow();
            w.Show();
        }

        private void btnRuler_Loaded(object sender, RoutedEventArgs e)
        {

        }









    
    }
}