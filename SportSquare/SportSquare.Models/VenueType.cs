using System.Collections.Generic;

namespace SportSquare.Models
{
    public class VenueType
    {
        private ICollection<Venue> venues;
        public int VenueTypeId { get; set; }

        public string Name { get; set; }

        public ICollection<Venue> Venues
        {
            get
            {
                return this.venues;
            }

            set
            {
                this.venues = value;
            }
        }
    }
}
