using SportSquare.MVP.Models.Search;
using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.AdminPanel
{
    public class EditVenuesViewModel : SearchViewModel
    {
        public VenueDTO Venue { get; set; }
    }
}