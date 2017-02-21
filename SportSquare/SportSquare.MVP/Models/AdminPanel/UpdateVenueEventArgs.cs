using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.AdminPanel
{
    public class UpdateVenueEventArgs : BasicEventArgs
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string WebAddress { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Image { get; private set; }

        public UpdateVenueEventArgs(object id, double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null) : base(id)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Name = name;
            this.Phone = phone;
            this.WebAddress = webAddress;
            this.Address = address;
            this.City = city;
            this.Image = image;
        }
    }
}