using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePolygon
    {
        string _status = ""; //N-New, D-Deleted, C-Changed, ''-No Action
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        string _id = "";
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        GooglePoints _gpoints = new GooglePoints();
        public GooglePoints Points
        {
            get { return _gpoints; }
            set { _gpoints = value; }
        }

        string _strokecolor = "#0000FF";
        public string StrokeColor
        {
            get { return _strokecolor; }
            set { _strokecolor = value; }
        }

        string _fillcolor = "#66FF00";
        public string FillColor
        {
            get { return _fillcolor; }
            set { _fillcolor = value; }
        }

        int _strokeweight = 10;
        public int StrokeWeight
        {
            get { return _strokeweight; }
            set { _strokeweight = value; }
        }

        double _strokeopacity = 1;
        public double StrokeOpacity
        {
            get { return _strokeopacity; }
            set { _strokeopacity = value; }
        }

        double _fillopacity = 0.2;
        public double FillOpacity
        {
            get { return _fillopacity; }
            set { _fillopacity = value; }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            GooglePolygon p = obj as GooglePolygon;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (FillColor == p.FillColor) && (FillOpacity == p.FillOpacity) && (p.ID == ID) && (p.Status == Status) && (p.StrokeColor == StrokeColor) && (p.StrokeOpacity == StrokeOpacity) && (p.StrokeWeight == StrokeWeight) && (p.Points.Equals(Points));
        }

    }

}
