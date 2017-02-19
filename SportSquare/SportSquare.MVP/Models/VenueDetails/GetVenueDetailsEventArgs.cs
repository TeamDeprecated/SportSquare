using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportSquare.MVP.Models.VenueDetails
{
    public class GetVenueDetailsEventArgs:EventArgs
    {
        public int? Id { get; private set; }

        public GetVenueDetailsEventArgs(int? id)
        {
            this.Id = id;
        }

    }
}