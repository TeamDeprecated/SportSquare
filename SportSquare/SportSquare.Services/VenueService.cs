using AutoMapper;
using SportSquare.Data.Contracts;
using SportSquare.Models;
using SportSquare.Services.Contracts;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportSquare.Services
{
    public class VenueService: IVenueService
    {
        private readonly IVenueRepository venueRepository;
        private readonly IMapper mapper;

        public VenueService(IVenueRepository venueRepository)
        {
            if (venueRepository == null)
            {
                throw new ArgumentNullException(nameof(venueRepository));
            }
            this.venueRepository = venueRepository;
        }

        public IEnumerable<VenueDTO> FilterVenues(string filter, string location)
        {
            //TODO fix this shit IpInfoGatherer should return City in Cyrilic!
            var venues = this.venueRepository.FilterVenues(filter, location);
            return Mapper.Map<IEnumerable<Venue>, IEnumerable<VenueDTO>>(venues);
        }
    }
}
