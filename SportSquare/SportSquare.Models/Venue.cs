using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using SportSquare.Models.Contracts;


namespace SportSquare.Models
{
    public class Venue : IDbModel
    {
        // TODO: Must be added validations!

        private ICollection<Rating> ratings;
        private ICollection<UserWishVenue> userWishVenue;
        private ICollection<Comment> comments;
        private ICollection<VenueType> venueTypes;

        public Venue()
        {
            this.ratings = new HashSet<Rating>();
            this.userWishVenue = new HashSet<UserWishVenue>();
            this.comments = new HashSet<Comment>();
            this.venueTypes = new HashSet<VenueType>();
            this.IsHidden = false;
        }

        public Venue(double latitude, double longitude, string image, string name, string phone, string webAddress,  string address, string city) : this()
        {

            this.Latitude = latitude;
            this.Longitude =longitude;
            this.Image = image;
            this.Name = name;
            this.Phone = phone;
            this.WebAddress = webAddress;
            this.Address = address;
            this.City = city;
        }

        public int Id { get; set; }

        public string Image { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string WebAddress { get; set; }

        public virtual ICollection<VenueType> VenueTypes
        {
            get
            {
                return this.venueTypes;
            }
            set
            {
                this.venueTypes = value;
            }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
        public virtual ICollection<UserWishVenue> UserWishVenue
        {
            get { return this.userWishVenue; }
            set { this.userWishVenue = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool IsHidden { get; set; }
    }
}
