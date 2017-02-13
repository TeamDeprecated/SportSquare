using SportSquare.Models;
using System.Collections.Generic;

namespace EF.Model
{
    public class Venue
    {
        // TODO: Must be added validations!

        private ICollection<Rating> ratings;
        private ICollection<Comment> comments;
        private ICollection<VenueType> venueTypes;
        public Venue()
        {

        }

        public Venue(double latitude, double longitude, string image, string name, string phone, string webAddress,  string address, string city)
        {

            this.Latitude = latitude;
            this.Longitude =longitude;
            this.Image = image;
            this.Name = name;
            this.Phone = phone;
            this.WebAddress = webAddress;
            this.Address = address;
            this.City = city;

            this.ratings = new HashSet<Rating>();
            this.comments = new HashSet<Comment>();
            this.venueTypes = new HashSet<VenueType>();
        }

        // Guid cheched to Int.....temporarily
        public int VenueId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

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

        public string WebAddress { get; set; }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public bool IsDeleted { get; set; }
    }
}
