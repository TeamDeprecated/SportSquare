using System;
using System.Collections.Generic;
using System.Xml;
using EF.Model;
using System.Reflection;
using System.IO;

namespace SportSquare.VenueImporter
{
    public class VenueImporter
    {   
        private const string FILE_PATH = "\\SportSquare.VenueImporter\\venueList.xml";
        public IList<Venue> Venues { get; private set; }
        public VenueImporter()
        {
            this.Venues =  new List<Venue>();
        }

        public IList<Venue> ParseVenues()
        {
            var directory = Directory.GetCurrentDirectory();
                //Environment.CurrentDirectory;

            using (var reader = XmlReader.Create(directory+FILE_PATH))
            {
                double latitude = 0.0;
                double longitude = 0.0;
                string image = "";
                string name = "";
                string city = "";
                string address = "";
                string phone = "";
                string webAddress = "";
                string[] venueType = new string[1];
                bool isInsideDiv = false;
                bool isInsideInfo = false;
                while (reader.Read())
                {
                    if (reader.AttributeCount > 0 && reader.GetAttribute(0) == "sp-club clearfix")
                    {
                        latitude = double.Parse(reader.GetAttribute(1));
                        longitude = double.Parse(reader.GetAttribute(1));
                    }
                    if (reader.AttributeCount > 0 && reader.GetAttribute(0) == "image col-xs-4")
                    {
                        isInsideDiv = true;
                    }
                    if (reader.AttributeCount > 0 && reader.GetAttribute(0) == "info")
                    {
                        isInsideInfo = true;
                    }

                    if (isInsideDiv && reader.Name == "img")
                    {
                        image = reader.GetAttribute(0);
                        isInsideDiv = false;
                    }
                    if (isInsideInfo && reader.Name == "h4" && reader.NodeType == XmlNodeType.Element)
                    {
                        reader.Read();
                        name = reader.Value;
                    }
                    if (isInsideInfo && reader.Name == "p" && reader.NodeType == XmlNodeType.Element && reader.GetAttribute(0) == "city")
                    {
                        reader.Read();
                        city = reader.Value;
                    }
                    if (isInsideInfo && reader.Name == "p" && reader.NodeType == XmlNodeType.Element && reader.GetAttribute(0) == "address")
                    {
                        reader.Read();
                        address = reader.Value;
                    }

                    if (isInsideInfo && reader.AttributeCount > 0 && reader.GetAttribute(0) == "phone")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            reader.Read();

                        }
                        phone = reader.Value;
                    }
                    if (isInsideInfo && reader.AttributeCount > 0 && reader.GetAttribute(0) == "www")
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            reader.Read();

                        }
                        webAddress = reader.Value;
                    }
                    if (isInsideInfo && reader.AttributeCount > 0 && reader.GetAttribute(0) == "type")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            reader.Read();

                        }
                        venueType = reader.Value.Split(',');
                        isInsideInfo = false;
                    }
                    if (reader.AttributeCount > 0 && reader.GetAttribute(0) == "benefits")
                    {
                        var venue = new Venue(latitude, longitude, image, name, phone, webAddress, venueType,address,city);
                        this.Venues.Add(venue);
                    }

                }
            }
            return Venues;

        }
    }
}
