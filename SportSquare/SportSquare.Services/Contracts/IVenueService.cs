using SportSquare.Models;
using SportSquareDTOs;
using System.Collections.Generic;


namespace SportSquare.Services.Contracts
{
    public interface IVenueService : ISportSquareGenericService<Venue>
    {
        void CreateVenue(double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null);

        void UpdateVenue(string id, double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null);

        IEnumerable<VenueDTO> FilterVenues(string filter, string location);
        VenueDetailedDTO GetVenue(int? id);
    }
}
