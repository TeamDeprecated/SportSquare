using AutoMapper;
using EF.Model;
using SportSquare.Models;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.App_Start.AutomapperProfiles
{
    public class VenueProfiles : Profile
    {
      public VenueProfiles()
        {
            this.CreateMap<Venue, VenueDTO>()
                .ForMember(dest => dest.VenueTypes, opt => opt.MapFrom(v=>v.VenueTypes));
            this.CreateMap<VenueType, VenueTypeDTO>()
                .ForMember(x => x.Name, opt => opt.MapFrom(v => v.Name));
        } 

    }
}