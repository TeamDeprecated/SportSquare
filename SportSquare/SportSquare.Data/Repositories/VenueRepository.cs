using System.Collections.Generic;
using System.Linq;

using SportSquare.Models;
using SportSquare.Data.Contracts;

namespace SportSquare.Data.Repositories
{
    public class VenueRepository : GenericRepository<Venue>, IVenueRepository, IGenericRepository<Venue>
    {
        public VenueRepository(ISportSquareDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Venue> FilterVenues(string filter, string location)
        {
            return this.GetAll(x => x.City == location && x.VenueTypes.Any(vt => vt.Name.Contains(filter)));
        }

        public IEnumerable<Venue> FilterVenues(string filter)
        {
            return this.GetAll(x => x.VenueTypes.Any(vt => vt.Name.Contains(filter)));
        }

        public IEnumerable<Venue> GetVenuesByLocation(string city)
        {
            return this.GetAll(x => x.City == city);
        }
    }
}
