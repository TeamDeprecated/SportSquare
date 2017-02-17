using System.Collections.Generic;

using SportSquare.Models.Contracts;

namespace SportSquare.Models
{
    public class VenueType : IDbModel
    {
        private ICollection<Venue> venues;

        public VenueType()
        {
            this.venues = new HashSet<Venue>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Venue> Venues
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

        public bool IsDeleted { get; set; }
    }
}
