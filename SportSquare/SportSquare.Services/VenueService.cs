using AutoMapper;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Models.Factories;
using SportSquare.Services.Contracts;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportSquare.Services
{
    public class VenueService: SportSquareGenericService<Venue>, IVenueService
    {
        private readonly IVenueFactory venueFactory;

        public VenueService(IGenericRepository<Venue> repository, IUnitOfWork unitOfWork, IVenueFactory venueFactory) : base(repository, unitOfWork)
        {
            if (venueFactory == null)
            {
                throw new ArgumentNullException("VenueFactory can't be null!");
            }

            this.venueFactory = venueFactory;
        }


        public void CreateVenue(double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null)
        {
            var venue = this.venueFactory.CreateVenue(latitude, longitude, name, phone, webAddress, address, city, image);

            this.Add(venue);
        }

        public void UpdateVenue(string venueId, double latitude, double longitude, string name, string phone, string webAddress, string address, string city, string image = null)
        {
            var venueGuid = Guid.Parse(venueId);
            var venue = this.GetById(venueGuid);

            venue.Latitude = latitude;
            venue.Longitude = longitude;
            venue.Name = name ?? venue.Name;
            venue.Phone = phone ?? venue.Phone;
            venue.WebAddress = webAddress ?? venue.WebAddress;
            venue.Address = address ?? venue.Address;
            venue.City = city ?? venue.City;
            venue.Image = image ?? venue.Image;

            this.Add(venue);
        }

        public IEnumerable<VenueDTO> FilterVenues(string filter, string location)
        {
            var venues = this.Repository.GetAll(x => x.City == location && x.VenueTypes.Any(vt => vt.Name.Contains(filter)));

            return Mapper.Map<IEnumerable<Venue>, IEnumerable<VenueDTO>>(venues);
        }

        public VenueDetailedDTO GetVenue(int? id)
        {
            if (!id.HasValue)
            {
                return null;
            }
            var venue = this.Repository.GetById(id);
            return Mapper.Map<Venue, VenueDetailedDTO>(venue);

        }
    }
}
