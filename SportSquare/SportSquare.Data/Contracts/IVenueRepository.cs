using System.Collections.Generic;

using SportSquare.Models;

namespace SportSquare.Data.Contracts
{
    public interface IVenueRepository : IGenericRepository<Venue>
    {
        IEnumerable<Venue> GetVenuesByLocation(string city);

        IEnumerable<Venue> FilterVenues(string filter, string location);

        IEnumerable<Venue> FilterVenues(string filter);
    }
}
