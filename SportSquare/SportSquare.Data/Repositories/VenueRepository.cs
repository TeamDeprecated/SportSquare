using EF.Model;
using SportSquare.Data.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SportSquare.Data.Repositories
{
    public class VenueRepository : GenericRepository<Venue>,IVenueRepository, IGenericRepository<Venue>
    {
        public VenueRepository(ISportSquareDbContext context) : base(context)
        {

        }

        public IEnumerable<Venue> FilterVenues(string filter, string location)
        {
            return base.Context.Venues
                .Where(x=>x.City==location)
                .Where(v => v.VenueTypes
                .Where(vt => vt.Name.Contains(filter))
                .Any()
                ).ToList();
               

        }
        public IEnumerable<Venue> FilterVenues(string filter)
        {
            return base.Context.Venues
              .Where(v => v.VenueTypes
              .Where(vt => vt.Name.Contains(filter))
              .Any()
              ).ToList();

        }
        public IEnumerable<Venue> GetVenuesByLocation(string city)
        {
            return base.Context.Venues.Where(x => x.City.ToString().ToLower() == city).Where(y => y.VenueTypes.Any()).ToList();

        }
    }
}
