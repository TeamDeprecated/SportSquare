using EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSquare.Data.Contracts
{
    public interface IVenueRepository: IGenericRepository<Venue>
    {
        IEnumerable<Venue> GetVenuesByLocation(string city);
        IEnumerable<Venue> FilterVenues(string filter, string location);
        IEnumerable<Venue> FilterVenues(string filter);


    }
}
