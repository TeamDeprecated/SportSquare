using SportSquareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.Search
{
    public class SearchViewModel
    {
        public IEnumerable<VenueDTO> FilteredVenues { get; set; }

    }
}