using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SportSquare.Models
{
    public class Venue
    {
        [Key]
        public Guid  Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Image { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public string[] VenueType { get; set; }

        public string WebAddress { get; set; }

        public Venue(double latitude, double longitude, string image, string name, string phone, string webAddress, string[] venueType, string address, string city)
        {
            this.Id = Guid.NewGuid();
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Image = image;
            this.Name = name;
            this.Phone = phone;
            this.WebAddress = webAddress;
            this.VenueType = venueType;
            this.Address = address;
            this.City = city;
        }
    }
}