using AutoMapper;
using EF.Model;
using SportSquare.Models;
using SportSquareDTOs;
using System.Linq;

namespace SportSquare.MVP.App_Start.AutomapperProfiles
{
    public class RatingResolverGeneric : IValueResolver<Venue, VenueDTO, double>
    {
        public double Resolve(Venue source, VenueDTO destination, double destMember, ResolutionContext context)
        {
            if (source.Ratings.Count() == 0)
            {
                return 0;
            }
            var total = 0;
            foreach (var rate in source.Ratings)
            {
                total += rate.Rate;
            }
            return total / (double)source.Ratings.Count();
        }
    }

}