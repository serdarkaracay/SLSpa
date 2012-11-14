using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using C1.Silverlight.Maps;
using System.Collections.Generic;

namespace iDeal.silverlight.controls
{

    public class iDealRTSMapSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/default.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/default.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public iDealRTSMapSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat.Length], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

    public class iDealMapSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/id.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/id.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public iDealMapSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat .Length ], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

    public class GoogleSatSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/go.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/go.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public GoogleSatSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat.Length], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

    public class GoogleMapSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/gm.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/gm.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public GoogleMapSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat.Length], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

    public class VirtualEarthMapSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/ve.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/ve.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public VirtualEarthMapSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat.Length], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

    public class OpenStreetMapSource : C1MultiScaleTileSource
    {
        string[] uriFormat = new string[]{
           @"http://93.187.207.238/MAPSERVER0/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER1/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER2/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER3/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER4/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER5/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER6/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.238/MAPSERVER7/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER0/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER1/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER2/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER3/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER4/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER5/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER6/op.aspx?p={0}_{1}_{2}",
           @"http://93.187.207.235/MAPSERVER7/op.aspx?p={0}_{1}_{2}"};

        public string Style = "1";
        public OpenStreetMapSource()
            : base(0x0000800, 0x0000800, 256, 256, 0)
        {

        }


        string uri = "";
        int serverNumber = 0;
        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
        {
            if (tileLevel > 8)
            {
                uri = string.Format(uriFormat[serverNumber++ % uriFormat.Length], tileLevel - 8, tilePositionX, tilePositionY);
                sources.Add(new Uri(uri));
            }
        }
    }

}
