using System.Linq;

using AutoMapper;

using SportSquare.Models;
using SportSquareDTOs;

namespace SportSquare.MVP.App_Start.AutomapperProfiles
{
    public class RatingResolverGeneric : IValueResolver<Venue, VenueDTO, int>
    {
        public int Resolve(Venue source, VenueDTO destination, int destMember, ResolutionContext context)
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
            return total / source.Ratings.Count();
        }
    }
}