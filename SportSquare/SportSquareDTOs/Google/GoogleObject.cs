//   Google Maps User Control for ASP.Net version 1.0:
//   ========================
//   Copyright (C) 2008  Shabdar Ghata 
//   Email : ghata2002@gmail.com
//   URL : http://www.shabdar.org

//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.

//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.

//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.

//   This program comes with ABSOLUTELY NO WARRANTY.

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.ComponentModel;
using SportSquareDTOs.GoogleApiModels;

/// <summary>
/// Summary description for cGoogleMap
/// </summary>
/// 
[Serializable]
public class GoogleObject
{
    public GoogleObject()
    {
    }

    public GoogleObject(GoogleObject prev)
    {
        Directions = prev.Directions;
        Points = GooglePoints.CloneMe(prev.Points);
        Polylines = GooglePolylines.CloneMe(prev.Polylines);
        Polygons = GooglePolygons.CloneMe(prev.Polygons);
        ZoomLevel = prev.ZoomLevel;
        ShowZoomControl = prev.ShowZoomControl;
        ShowMapTypesControl = prev.ShowMapTypesControl;
        Width = prev.Width;
        Height = prev.Height;
        MapType = prev.MapType;
        APIKey = prev.APIKey;
        ShowTraffic = prev.ShowTraffic;
        RecenterMap = prev.RecenterMap;
        AutomaticBoundaryAndZoom = prev.AutomaticBoundaryAndZoom;
    }

    private GoogleDirections _gdirections = new GoogleDirections();
    public GoogleDirections Directions
    {
        get { return _gdirections; }
        set { _gdirections = value; }
    }

    GooglePoints _gpoints = new GooglePoints();
    public GooglePoints Points
    {
        get { return _gpoints; }
        set { _gpoints = value; }
    }

    GooglePolylines _gpolylines = new GooglePolylines();
    public GooglePolylines Polylines
    {
        get { return _gpolylines; }
        set { _gpolylines = value; }
    }

    GooglePolygons _gpolygons = new GooglePolygons();
    public GooglePolygons Polygons
    {
        get { return _gpolygons; }
        set { _gpolygons = value; }
    }

    GooglePoint _centerpoint = new GooglePoint();
    public GooglePoint CenterPoint
    {
        get { return _centerpoint; }
        set { _centerpoint = value; }
    }

    int _zoomlevel = 3;
    public int ZoomLevel
    {
        get { return _zoomlevel; }
        set { _zoomlevel = value; }
    }

    bool _showzoomcontrol = true;
    public bool ShowZoomControl
    {
        get { return _showzoomcontrol; }
        set { _showzoomcontrol = value; }
    }

    bool _recentermap = false;
    public bool RecenterMap
    {
        get { return _recentermap; }
        set { _recentermap = value; }
    }

    bool _ispostback = false;
    public bool IsPostback
    {
        get { return _ispostback; }
        set { _ispostback = value; }
    }


    bool _automaticboundaryandzoom = false;
    public bool AutomaticBoundaryAndZoom
    {
        get { return _automaticboundaryandzoom; }
        set { _automaticboundaryandzoom = value; }
    }

    bool _showtraffic = false;
    public bool ShowTraffic
    {
        get { return _showtraffic; }
        set { _showtraffic = value; }
    }

    bool _showmaptypescontrol = true;
    public bool ShowMapTypesControl
    {
        get { return _showmaptypescontrol; }
        set { _showmaptypescontrol = value; }
    }

    string _width = "500px";
    public string Width
    {
        get
        {
            return _width;
        }
        set
        {
            _width = value;
        }
    }

    string _height = "400px";
    public string Height
    {
        get
        {
            return _height;
        }
        set
        {
            _height = value;
        }
    }


    string _maptype = "";
    public string MapType
    {
        get
        {
            return _maptype;
        }
        set
        {
            _maptype = value;
        }
    }

    string _apikey = "";
    public string APIKey
    {
        get
        {
            return _apikey;
        }
        set
        {
            _apikey = value;
        }
    }

    string _apiversion = "2";
    public string APIVersion
    {
        get
        {
            return _apiversion;
        }
        set
        {
            _apiversion = value;
        }
    }

}
