using AutoMapper;
using SportSquare.MVP.App_Start.AutomapperProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP
{
    public class AutoMapper
    {
       public void Initialize()
        {
            Mapper.Initialize(AddProfilesToAutomapperConfig);
        }

        private static void AddProfilesToAutomapperConfig(IMapperConfigurationExpression config)
        {
            config.AddProfile(new VenueProfiles());
            config.AddProfile(new VenueDetailedProfile());

        }
    }
}