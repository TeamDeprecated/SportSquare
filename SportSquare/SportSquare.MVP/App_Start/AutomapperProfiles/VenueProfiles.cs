using AutoMapper;
using EF.Model;
using SportSquare.Models;
using SportSquareDTOs;

namespace SportSquare.MVP.App_Start.AutomapperProfiles
{
    public class VenueProfiles : Profile
    {
        public VenueProfiles()
        {
            this.CreateMap<Venue, VenueDTO>()
                .ForMember(dest => dest.VenueTypes, opt => opt.MapFrom(v => v.VenueTypes))
                .ForMember(dest => dest.RatingAvarage, opt => opt.ResolveUsing<RatingResolver>());
            this.CreateMap<VenueType, VenueTypeDTO>()
              .ForMember(x => x.Name, opt => opt.MapFrom(v => v.Name));
        }
    }
  
}