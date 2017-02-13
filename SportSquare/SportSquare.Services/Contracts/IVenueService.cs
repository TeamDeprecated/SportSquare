    using EF.Model;
using SportSquareDTOs;
using System.Collections.Generic;


namespace SportSquare.Services.Contracts
{
    public interface IVenueService
    {
        IEnumerable<VenueDTO> FilterVenues(string filter, string location);
    }
}
