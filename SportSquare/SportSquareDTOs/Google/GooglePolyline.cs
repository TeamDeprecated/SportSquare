using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePolyline
    {
        string _linestatus = ""; //N-New, D-Deleted, C-Changed, ''-No Action
        public string LineStatus
        {
            get { return _linestatus; }
            set { _linestatus = value; }
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

        string _colorcode = "#66FF00";
        public string ColorCode
        {
            get { return _colorcode; }
            set { _colorcode = value; }
        }

        int _width = 10;
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        bool _geodesic = false;
        public bool Geodesic
        {
            get { return _geodesic; }
            set { _geodesic = value; }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            GooglePolyline p = obj as GooglePolyline;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (Geodesic == p.Geodesic) && (Width == p.Width) && (p.ID == ID) && (p.ColorCode == ColorCode) && (p.Points.Equals(Points));
        }

    }
}
