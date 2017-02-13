using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
