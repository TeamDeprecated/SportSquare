using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquareDTOs.GoogleApiModels
{
    public class GooglePoint
    {
        public GooglePoint()
        {
        }

        string _pointstatus = ""; //N-New, D-Deleted, C-Changed, ''-No Action
        public string PointStatus
        {
            get { return _pointstatus; }
            set { _pointstatus = value; }
        }


        string _address = "";
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }


        public GooglePoint(string pID, double plat, double plon, string picon, string pinfohtml)
        {
            ID = pID;
            Latitude = plat;
            Longitude = plon;
            IconImage = picon;
            InfoHTML = pinfohtml;
        }

        public GooglePoint(string pID, double plat, double plon, string picon, string pinfohtml, string pTooltipText, bool pDraggable)
        {
            ID = pID;
            Latitude = plat;
            Longitude = plon;
            IconImage = picon;
            InfoHTML = pinfohtml;
            ToolTip = pTooltipText;
            Draggable = pDraggable;
        }

        public GooglePoint(string pID, double plat, double plon, string picon)
        {
            ID = pID;
            Latitude = plat;
            Longitude = plon;
            IconImage = picon;
        }

        public GooglePoint(string pID, double plat, double plon)
        {
            ID = pID;
            Latitude = plat;
            Longitude = plon;
        }

        string _id = "";
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        string _icon = "";
        public string IconImage
        {
            get
            {
                return _icon;
            }
            set
            {

                //Get physical path of icon image. Necessary for Bitmap object.
                string sIconImage = value;
                if (sIconImage == "")
                    return;
                string ImageIconPhysicalPath = cCommon.GetLocalPath() + sIconImage.Replace("/", "\\");
                //Find width and height of icon using Bitmap image.


                using (System.Drawing.Image img = System.Drawing.Image.FromFile(ImageIconPhysicalPath))
                {
                    IconImageWidth = img.Width;
                    IconImageHeight = img.Height;

                    IconAnchor_posX = img.Width / 2;
                    IconAnchor_posY = img.Height;

                    InfoWindowAnchor_posX = img.Width / 2;
                    InfoWindowAnchor_posY = img.Height / 3;
                }
                _icon = cCommon.GetHttpURL() + sIconImage;


                _icon = value;
            }
        }

        string _iconshadowimage = "";
        public string IconShadowImage
        {
            get
            {
                return _iconshadowimage;
            }
            set
            {

                //Get physical path of icon image. Necessary for Bitmap object.
                string sShadowImage = value;
                if (sShadowImage == "")
                    return;
                string ShadowIconPhysicalPath = cCommon.GetLocalPath() + sShadowImage.Replace("/", "\\");
                //Find width and height of icon using Bitmap image.

                using (Image img = Image.FromFile(ShadowIconPhysicalPath))
                {
                    IconShadowWidth = img.Width;
                    IconShadowHeight = img.Height;
                }
                _iconshadowimage = cCommon.GetHttpURL() + sShadowImage;

                _iconshadowimage = value;
            }
        }

        int _iconimagewidth = 32;
        public int IconImageWidth
        {
            get
            {
                return _iconimagewidth;
            }
            set
            {
                _iconimagewidth = value;
            }
        }

        int _iconshadowwidth = 0;
        public int IconShadowWidth
        {
            get
            {
                return _iconshadowwidth;
            }
            set
            {
                _iconshadowwidth = value;
            }
        }

        int _iconshadowheight = 0;
        public int IconShadowHeight
        {
            get
            {
                return _iconshadowheight;
            }
            set
            {
                _iconshadowheight = value;
            }
        }

        int _iconanchor_posx = 16;
        public int IconAnchor_posX
        {
            get
            {
                return _iconanchor_posx;
            }
            set
            {
                _iconanchor_posx = value;
            }
        }
        int _iconanchor_posy = 32;
        public int IconAnchor_posY
        {
            get
            {
                return _iconanchor_posy;
            }
            set
            {
                _iconanchor_posy = value;
            }
        }

        int _infowindowanchor_posx = 16;
        public int InfoWindowAnchor_posX
        {
            get
            {
                return _infowindowanchor_posx;
            }
            set
            {
                _infowindowanchor_posx = value;
            }
        }

        int _infowindowanchor_posy = 5;
        public int InfoWindowAnchor_posY
        {
            get
            {
                return _infowindowanchor_posy;
            }
            set
            {
                _infowindowanchor_posy = value;
            }
        }

        bool _draggable = false;
        public bool Draggable
        {
            get
            {
                return _draggable;
            }
            set
            {
                _draggable = value;
            }
        }

        int _iconimageheight = 32;
        public int IconImageHeight
        {
            get
            {
                return _iconimageheight;
            }
            set
            {
                _iconimageheight = value;
            }
        }

        double _lat = 0.0;
        public double Latitude
        {
            get
            {
                return _lat;
            }
            set
            {
                _lat = value;
            }
        }

        double _lon = 0.0;
        public double Longitude
        {
            get
            {
                return _lon;
            }
            set
            {
                _lon = value;
            }
        }

        string _infohtml = "";
        public string InfoHTML
        {
            get
            {
                return _infohtml;
            }
            set
            {
                _infohtml = value;
            }
        }

        string _tooltip = "";
        public string ToolTip
        {
            get
            {
                return _tooltip;
            }
            set
            {
                _tooltip = value;
            }
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            GooglePoint p = obj as GooglePoint;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (InfoHTML == p.InfoHTML) && (IconImage == p.IconImage) && (p.ID == ID) && (p.Latitude == Latitude) && (p.Longitude == Longitude);
        }

        public bool GeocodeAddress()
        {
            return cCommon.GeocodeAddress(this);
        }

        public bool ReverseGeocode()
        {
            return cCommon.ReverseGeocode(this);
        }
    }
}
