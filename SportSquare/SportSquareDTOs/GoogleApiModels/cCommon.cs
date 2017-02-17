using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Threading.Tasks;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

namespace SportSquareDTOs.GoogleApiModels
{
    public class cCommon
    {
        public cCommon()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static Random random = new Random();
        public static bool IsNumeric(object s)
        {
            try
            {
                double.Parse(s.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }


        public static int GetIntegerValue(object pNumValue)
        {
            if ((pNumValue == null))
            {
                return 0;
            }
            if (IsNumeric(pNumValue))
            {
                return int.Parse((pNumValue.ToString()));
            }
            else
            {
                return 0;
            }
        }


        public static bool GeocodeAddress(GooglePoint GP)
        {
            string sURL = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + GP.Address + "&sensor=false";
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 10000;
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            StringReader tx = new StringReader(responseFromServer);

            //return false;
            //System.Xml.XmlReader xr = new System.Xml.XmlReader();

            //return false;

            DataSet DS = new DataSet();
            DS.ReadXml(tx);
            //DS.ReadXml(dataStream);
            //DS.ReadXml(tx);



            string status = cCommon.GetStringValue(DS.Tables["GeocodeResponse"].Rows[0]["status"]);
            if (status == "OK")
            {
                GP.Latitude = cCommon.GetNumericValue(DS.Tables["location"].Rows[0]["lat"]);
                GP.Longitude = cCommon.GetNumericValue(DS.Tables["location"].Rows[0]["lng"]);
                if (DS.Tables["result"] != null)
                {
                    GP.Address = cCommon.GetStringValue(DS.Tables["result"].Rows[0]["formatted_address"]);
                }
                return true;
            }
            return false;

        }


        public static bool ReverseGeocode(GooglePoint GP)
        {
            string sURL = "http://maps.googleapis.com/maps/api/geocode/xml?latlng=" + GP.Latitude.ToString() + "," + GP.Longitude.ToString() + "&sensor=false";
            WebRequest request = WebRequest.Create(sURL);
            request.Timeout = 10000;
            // Set the Method property of the request to POST.
            request.Method = "POST";
            // Create POST data and convert it to a byte array.
            string postData = "";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;
            // Get the request stream.
            Stream dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            StringReader tx = new StringReader(responseFromServer);

            //return false;
            //System.Xml.XmlReader xr = new System.Xml.XmlReader();

            //return false;

            DataSet DS = new DataSet();
            DS.ReadXml(tx);
            //DS.ReadXml(dataStream);
            //DS.ReadXml(tx);



            string status = cCommon.GetStringValue(DS.Tables["GeocodeResponse"].Rows[0]["status"]);
            if (status == "OK")
            {
                GP.Latitude = cCommon.GetNumericValue(DS.Tables["location"].Rows[0]["lat"]);
                GP.Longitude = cCommon.GetNumericValue(DS.Tables["location"].Rows[0]["lng"]);
                if (DS.Tables["result"] != null)
                {
                    GP.Address = cCommon.GetStringValue(DS.Tables["result"].Rows[0]["formatted_address"]);
                }
                return true;
            }
            return false;

        }



        public static double GetNumericValue(object pNumValue)
        {
            if ((pNumValue == null))
            {
                return 0;
            }
            if (IsNumeric(pNumValue))
            {
                return double.Parse((pNumValue.ToString()));
            }
            else
            {
                return 0;
            }
        }

        public static string GetStringValue(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            if ((obj == null))
            {
                return "";
            }
            if (!(obj == null))
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
        public static string GetHttpURL()
        {
            string[] s = HttpContext.Current.Request.Url.AbsoluteUri.Split(new char[] { '/' });
            string path = s[0] + "/";
            for (int i = 1; i < s.Length - 1; i++)
            {
                path = path + s[i] + "/";
            }
            return path;
        }

        public static string GetLocalPath()
        {
            string[] s = HttpContext.Current.Request.Url.AbsoluteUri.Split(new char[] { '/' });
            string PageName = s[s.Length - 1];
            s = HttpContext.Current.Request.MapPath(PageName).Split(new char[] { '\\' });
            string path = s[0] + "\\";
            for (int i = 1; i < s.Length - 1; i++)
            {
                path = path + s[i] + "\\";
            }
            return path;
        }

        public static decimal RandomNumber(decimal min, decimal max)
        {
            decimal Fractions = 10000000;
            int iMin = (int)GetIntegerPart(min * Fractions);
            int iMax = (int)GetIntegerPart(max * Fractions);
            int iRand = random.Next(iMin, iMax);

            decimal dRand = (decimal)iRand;
            dRand = dRand / Fractions;

            return dRand;
        }


        public static decimal GetFractional(decimal source)
        {
            return source % 1.0m;
        }

        public static decimal GetIntegerPart(decimal source)
        {
            return decimal.Parse(source.ToString("#.00"));
        }

    }
}
