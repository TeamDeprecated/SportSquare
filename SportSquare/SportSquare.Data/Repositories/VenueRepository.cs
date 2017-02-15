using System.Collections.Generic;
using System.Linq;

using SportSquare.Models;
using SportSquare.Data.Contracts;

namespace SportSquare.Data.Repositories
{
    public class VenueRepository : GenericRepository<Venue>,IVenueRepository, IGenericRepository<Venue>
    {
        public VenueRepository(ISportSquareDbContext context) : base(context)
        {

        }

        public IEnumerable<Venue> FilterVenues(string filter, string location)
        {
            return base.DbContext.Venues
                .Where(x=>x.City==location)
                .Where(v => v.VenueTypes
                .Where(vt => vt.Name.Contains(filter))
                    .Any())
                .ToList();
               

        }
        public IEnumerable<Venue> FilterVenues(string filter)
        {
            return base.DbContext.Venues
              .Where(v => v.VenueTypes
              .Where(vt => vt.Name.Contains(filter))
              .Any()
              ).ToList();

        }
        public IEnumerable<Venue> GetVenuesByLocation(string city)
        {
            return base.DbContext.Venues.Where(x => x.City.ToString().ToLower() == city).Where(y => y.VenueTypes.Any()).ToList();

        }
    }
}
