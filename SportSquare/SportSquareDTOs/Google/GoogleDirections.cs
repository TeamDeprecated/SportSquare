using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    [Serializable()]
    public class GoogleDirections
    {
        public GoogleDirections()
        {
        }

        private ArrayList _addresses = new ArrayList();
        public ArrayList Addresses
        {
            get { return _addresses; }
            set { _addresses = value; }

        }

        private string _locale = "en_US";
        public string Locale
        {
            get { return _locale; }
            set { _locale = value; }
        }


        private bool _showdirectioninstructions = false;
        public bool ShowDirectionInstructions
        {
            get { return _showdirectioninstructions; }
            set { _showdirectioninstructions = value; }
        }

        bool _hideMarkers = false;
        public bool HideMarkers
        {
            get { return _hideMarkers; }
            set { _hideMarkers = value; }
        }

        private double _polylineopacity = 0.6;
        // <summary>
        // Lokales Connection-Timeout Für Feld_Ausgeben().
        // </summary>    
        [Description("Direction line opacity. Valid values : 0.1 to 1.0")]
        public double PolylineOpacity
        {
            get { return _polylineopacity; }
            set { _polylineopacity = value; }
        }

        private int _polylineweight = 3;

        [Description("Direction line weight or width. Valid values : 1 to 10.")]
        public int PolylineWeight
        {
            get { return _polylineweight; }
            set { _polylineweight = value; }
        }

        private string _polylinecolor = "#0000FF";

        [Description("Direction line color")]
        public string PolylineColor
        {
            get { return _polylinecolor; }
            set { _polylinecolor = value; }
        }
    }

}
