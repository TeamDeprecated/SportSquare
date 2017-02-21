using AutoMapper;
using SportSquare.Models;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.App_Start.AutomapperProfiles
{
    public class VenueDetailedProfile : Profile
    {
        public VenueDetailedProfile()
        {

            this.CreateMap<Venue, VenueDetailedDTO>()
                .ForMember(dest => dest.VenueTypes, opt => opt.MapFrom(v => v.VenueTypes))
                .ForMember(dest => dest.RatingAvarage, opt => opt.ResolveUsing<RatingResolverGeneric>());
                

            this.CreateMap<Comment, CommentDTO>()
               .ForMember(dest => dest.User, opt => opt.MapFrom(u => u.User.FirstName));
        }

    }
}