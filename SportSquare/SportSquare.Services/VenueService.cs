using AutoMapper;
using EF.Model;
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
        private readonly IGenericRepository<Venue> repository;
        private readonly IVenueRepository venueRepository;

        public VenueService(IGenericRepository<Venue> repository, IVenueRepository venueRepository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;
            if (venueRepository == null)
            {
                throw new ArgumentNullException(nameof(venueRepository));
            }
            this.venueRepository = venueRepository;
        }

        public IEnumerable<VenueDTO> FilterVenues(string filter, string location)
        {
            //TODO fix this shit IpInfoGatherer should return City in Cyrilic!
            var venues = this.venueRepository.FilterVenues(filter,"софия");
            return Mapper.Map<IEnumerable<Venue>, IEnumerable<VenueDTO>>(venues);


        }
    }
}
